		public static bool IsAnagram(string s1, string s2) {
			if (s1.Length != s2.Length)
				return false;
			int i = -1;
			var chars = new Dictionary<char, int> ();
			Func <char, int, int, int> updateCount = (c, side, pdiff) => {
				int count = 0;
				chars.TryGetValue (c, out count);
				var newCount = count + side;
				chars[c] = newCount;
				if (count == 0)
					return pdiff + 1;
				else if (newCount == 0)
					return pdiff - 1;
				else
					return pdiff;
			};
			int diff = 0;
			foreach (var c1 in s1) {
				i++;
				var c2 = s2 [i];
				if (c1 == c2)
					continue;
				diff = updateCount(c1, 1, diff);
				diff = updateCount(c2, -1, diff);
			}
			return diff == 0;
		}
		public static void Main (string[] args)
		{
			string s1 = "asd";
			string s2 = "ads";
			Console.WriteLine (IsAnagram(s1, s2));
		}
