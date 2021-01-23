			var parts = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length > 1)
			{
				Dict.TryAdd(parts[0], parts[1]);
			}
			else
			{
				// ERROR logging
			}
