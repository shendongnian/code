        char[] availableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_=+*".ToArray();
		IEnumerable<string> CreatePassword(int size)
		{
			
			if (size == 1 )
			{
				foreach (var c in availableChars)
				{
					yield return c.ToString();
				}
				yield break;
			}
			foreach (var password in CreatePassword(size - 1))
			{
				foreach (var c in availableChars)
				{
					yield return password + c;
				}
			}
		}
