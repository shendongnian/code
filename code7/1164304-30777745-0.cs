	// Returns the directory path of a file path. This method effectively
	// removes the last element of the given file path, i.e. it returns a
	// string consisting of all characters up to but not including the last
	// backslash ("\") in the file path. The returned value is null if the file
	// path is null or if the file path denotes a root (such as "\", "C:", or
	// "\\server\share").
	//
	public static String GetDirectoryName(String path)
	{
		if (path != null)
		{
			CheckInvalidPathChars(path);
	#if FEATURE_LEGACYNETCF
			if (!CompatibilitySwitches.IsAppEarlierThanWindowsPhone8)
			{
	#endif
				string normalizedPath = NormalizePath(path, false);
				// If there are no permissions for PathDiscovery to this path, we should NOT expand the short paths
				// as this would leak information about paths to which the user would not have access to.
				if (path.Length > 0)
				{
					try
					{
						// If we were passed in a path with \\?\ we need to remove it as FileIOPermission does not like it.
						string tempPath = Path.RemoveLongPathPrefix(path);
						// FileIOPermission cannot handle paths that contain ? or *
						// So we only pass to FileIOPermission the text up to them.
						int pos = 0;
						while (pos < tempPath.Length && (tempPath[pos] != '?' && tempPath[pos] != '*'))
							pos++;
						// GetFullPath will Demand that we have the PathDiscovery FileIOPermission and thus throw 
						// SecurityException if we don't. 
						// While we don't use the result of this call we are using it as a consistent way of 
						// doing the security checks. 
						if (pos > 0)
							Path.GetFullPath(tempPath.Substring(0, pos));
					}
					catch (SecurityException)
					{
						// If the user did not have permissions to the path, make sure that we don't leak expanded short paths
						// Only re-normalize if the original path had a ~ in it.
						if (path.IndexOf("~", StringComparison.Ordinal) != -1)
						{
							normalizedPath = NormalizePath(path, /*fullCheck*/ false, /*expandShortPaths*/ false);
						}
					}
					catch (PathTooLongException) { }
					catch (NotSupportedException) { }  // Security can throw this on "c:\foo:"
					catch (IOException) { }
					catch (ArgumentException) { } // The normalizePath with fullCheck will throw this for file: and http:
				}
				path = normalizedPath;
	#if FEATURE_LEGACYNETCF
			}
	#endif
			int root = GetRootLength(path);
			int i = path.Length;
			if (i > root)
			{
				i = path.Length;
				if (i == root) return null;
				while (i > root && path[--i] != DirectorySeparatorChar && path[i] != AltDirectorySeparatorChar) ;
				String dir = path.Substring(0, i);
	#if FEATURE_LEGACYNETCF
				if (CompatibilitySwitches.IsAppEarlierThanWindowsPhone8)
				{
					if (dir.Length >= MAX_PATH - 1)
						throw new PathTooLongException(Environment.GetResourceString("IO.PathTooLong"));
				}
	#endif
				return dir;
			}
		}
		return null;
	}
