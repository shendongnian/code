csharp
        public static void EnsureDirectory(this SftpClient client, string path)
		{
			if (path.Length is 0)
				return;
			var curIndex = 0;
			var todo = path.AsSpan();
			if (todo[0] == '/' || todo[0] == '\\')
			{
				todo = todo.Slice(1);
				curIndex++;
			}
			while (todo.Length > 0)
			{
				var endOfNextIndex = todo.IndexOf('/');
				if (endOfNextIndex < 0)
					endOfNextIndex = todo.IndexOf('\\');
				string current;
				if (endOfNextIndex >= 0)
				{
					curIndex += endOfNextIndex + 1;
					current = path.Substring(0, curIndex);
					todo = path.AsSpan().Slice(curIndex);
				}
				else
				{
					current = path;
					todo = ReadOnlySpan<char>.Empty;
				}
				try
				{
					client.CreateDirectory(current);
				}
				catch (SshException ex) when (ex.Message == "Already exists.") { }
			}
		}
