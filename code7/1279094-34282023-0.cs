                    String dllName = new AssemblyName(bargs.Name).Name + ".dll";
                    var assem = Assembly.GetExecutingAssembly();
                    String resourceName = assem.GetManifestResourceNames().FirstOrDefault(rn => rn.EndsWith(dllName));
                    if (resourceName == null) return null; // For null assembly
                    using (var stream = assem.GetManifestResourceStream(resourceName))
                    {
                        Byte[] assemblyData = new Byte[stream.Length];
                        stream.Read(assemblyData, 0, assemblyData.Length);
                        return Assembly.Load(assemblyData);
                    }
                };
