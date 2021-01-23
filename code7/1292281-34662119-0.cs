    	static string PathUp (string path, int up)
		{
			if (up == 0)
				return path;
			for (int i = path.Length -1; i >= 0; i--) {
				if (path[i] == Path.DirectorySeparatorChar) {
					up--;
					if (up == 0)
						return path.Substring (0, i);
				}
			}
			return null;
		}
    string prefix = PathUp (typeof (int).Assembly.Location, 4);
