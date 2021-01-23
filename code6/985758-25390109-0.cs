	/// <summary>
	/// Fixes references in assembly pointing to other assemblies to make their PublicKeyToken-s compatible. Returns true if some changes were made.
	/// <para>Inspiration comes from https://github.com/brutaldev/StrongNameSigner/blob/master/src/Brutal.Dev.StrongNameSigner.UI/MainForm.cs
	/// see call to SigningHelper.FixAssemblyReference
	/// </para>
	/// </summary>
	public static bool FixStrongNameReferences(IEngine engine, string assemblyFile, string keyFile, string password)
	{
		var modified = false;
		assemblyFile = Path.GetFullPath(assemblyFile);
		var assemblyHasStrongName = GetAssemblyInfo(assemblyFile, AssemblyInfoFlags.Read_StrongNameStatus)
			.StrongNameStatus == StrongNameStatus.Present;
		using (var handle = new AssemblyHandle(engine, assemblyFile))
		{
			AssemblyDefinition a;
			var resolver = handle.GetAssemblyResolver();
			a = handle.AssemblyDefinition;
			foreach (var reference in a.MainModule.AssemblyReferences)
			{
				var b = resolver.Resolve(reference);
				if (b != null)
				{
					// Found a matching reference, let's set the public key token.
					if (BitConverter.ToString(reference.PublicKeyToken) != BitConverter.ToString(b.Name.PublicKeyToken))
					{
						reference.PublicKeyToken = b.Name.PublicKeyToken ?? new byte[0];
						modified = true;
					}
				}
			}
			foreach (var resource in a.MainModule.Resources.ToList())
			{
				var er = resource as EmbeddedResource;
				if (er != null && er.Name.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
				{
					using (var targetStream = new MemoryStream())
					{
						bool resourceModified = false;
						using (var sourceStream = er.GetResourceStream())
						{
							using (System.Resources.IResourceReader reader = new System.Resources.ResourceReader(sourceStream))
							{
								using (var writer = new System.Resources.ResourceWriter(targetStream))
								{
									foreach (DictionaryEntry entry in reader)
									{
										var key = (string)entry.Key;
										if (entry.Value is string)
										{
											writer.AddResource(key, (string)entry.Value);
										}
										else
										{
											if (key.EndsWith(".baml", StringComparison.OrdinalIgnoreCase) && entry.Value is Stream)
											{
												Stream newBamlStream = null;
												if (FixStrongNameReferences(handle, (Stream)entry.Value, ref newBamlStream))
												{
													writer.AddResource(key, newBamlStream, closeAfterWrite: true);
													resourceModified = true;
												}
												else
												{
													writer.AddResource(key, entry.Value);
												}
											}
											else
											{
												writer.AddResource(key, entry.Value);
											}
										}
									}
								}
							}
							if (resourceModified)
							{
								targetStream.Flush();
								// I'll swap new resource instead of the old one
								a.MainModule.Resources.Remove(resource);
								a.MainModule.Resources.Add(new EmbeddedResource(er.Name, resource.Attributes, targetStream.ToArray()));
								modified = true;
							}
						}
					}
				}
			}
			if (modified)
			{
				string backupFile = SigningHelper.GetTemporaryFile(assemblyFile, 1);
				// Make a backup before overwriting.
				File.Copy(assemblyFile, backupFile, true);
				try
				{
					try
					{
						AssemblyResolver.RunDefaultAssemblyResolver(Path.GetDirectoryName(assemblyFile), () => {
							// remove previous strong name https://groups.google.com/forum/#!topic/mono-cecil/5If6OnZCpWo
							a.Name.HasPublicKey = false;
							a.Name.PublicKey = new byte[0];
							a.MainModule.Attributes &= ~ModuleAttributes.StrongNameSigned;
							a.Write(assemblyFile);
						});
						if (assemblyHasStrongName)
						{
							SigningHelper.SignAssembly(assemblyFile, keyFile, null, password);
						}
					}
					catch (Exception)
					{
						// Restore the backup if something goes wrong.
						File.Copy(backupFile, assemblyFile, true);
						throw;
					}
				}
				finally
				{
					File.Delete(backupFile);
				}
			}
		}
		return modified;
	}
