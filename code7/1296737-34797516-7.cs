	private unsafe static void test()
	{
		var loops = 1000000;
		var arrayExisting = Enumerable.Repeat(-1, 1000).ToArray();
		var arrayReplacements = Enumerable.Repeat(1, 1000).ToArray();
		int[] newArray = null;
		var selectTimer = Stopwatch.StartNew();
		for (var j = 0; j < loops; j++)
		{
			var i = 0;
			newArray = arrayExisting.Select(val =>
			{
				if (val != -1) return val;
				var ret = arrayReplacements[i];
				i++;
				return ret;
			}).ToArray();
		}
		selectTimer.Stop();
		printResult("linQ", newArray);
		arrayExisting = Enumerable.Repeat(-1, 1000).ToArray();
		arrayReplacements = Enumerable.Repeat(1, 1000).ToArray();
		int[] replaced = null;
		var forTimer = Stopwatch.StartNew();
		for (var j = 0; j < loops; j++)
		{
			replaced = new int[arrayExisting.Length];
			int replacementIndex = 0;
			for (var i = 0; i < arrayExisting.Length; i++)
			{
				if (arrayExisting[i] < 0)
				{
					replaced[i] = arrayReplacements[replacementIndex++];
				}
				else
				{
					replaced[i] = arrayExisting[i];
				}
			}
		}
		forTimer.Stop();
		printResult("for", replaced);
		arrayExisting = Enumerable.Repeat(-1, 1000).ToArray();
		arrayReplacements = Enumerable.Repeat(1, 1000).ToArray();
		int[] copy = null;
		var pointerTimer = Stopwatch.StartNew();
        //EDIT: fixed the test code
		for (int j = 0; j < loops; j++)
		{
			copy = new int[arrayExisting.Length];
			Array.Copy(arrayExisting, copy, arrayExisting.Length);
			int replacementsLength = arrayReplacements.Length;
			int existingLength = arrayExisting.Length;
			fixed (int* existing = copy, replacements = arrayReplacements)
			{
				int* exist = existing;
				int* replace = replacements;
				int i = 0;
				int x = 0;
				while (i < replacementsLength && x < existingLength)
				{
					if (*exist == -1)
					{
						*exist = *replace;
						i++;
						replace++;
					}
					exist++;
					x++;
				}
			}
		}
		pointerTimer.Stop();
		printResult("pointer", copy);
		File.AppendAllText(@"E:\dev\test.txt", "\r\n" +
			"Select: " + selectTimer.ElapsedMilliseconds + "\r\n" +
			"For: " + forTimer.ElapsedMilliseconds + "\r\n" + 
			"Pointer: " + pointerTimer.ElapsedMilliseconds);
	}
