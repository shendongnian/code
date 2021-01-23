            var lWatch = new Stopwatch();
			var s = "ABCDCBA";
			bool result;
			bool isPalindrome;
			////Simple array element comparison
			lWatch.Restart();
			for (int j = 0; j < 1000000; j++)
				result = Enumerable
					.Range(0, s.Length)
					.All(i => s[i] == s[s.Length - 1 - i]);
			lWatch.Stop();
			Console.WriteLine(lWatch.Elapsed);
			////Sequence reversal and comparison
			lWatch.Restart();
			for (int j = 0; j < 1000000; j++)
				isPalindrome = s.SequenceEqual(s.Reverse());
			lWatch.Stop();
			Console.WriteLine(lWatch.Elapsed);
			////Simple array element comparison; respecting casing
			lWatch.Restart();
			for (int j = 0; j < 1000000; j++)
				result = Enumerable
					.Range(0, s.Length)
					.All(i => char.ToUpper(s[i]) == char.ToUpper(s[s.Length - 1 - i]));
			lWatch.Stop();
			Console.WriteLine(lWatch.Elapsed);
			////Sequence reversal and comparison; respecting casing
			lWatch.Restart();
			for (int j = 0; j < 1000000; j++)
				isPalindrome = s.Select(c => char.ToUpper(c)).SequenceEqual(s.Select(c => char.ToUpper(c)).Reverse());
			lWatch.Stop();
			Console.WriteLine(lWatch.Elapsed);
