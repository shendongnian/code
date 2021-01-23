 		static IEnumerable<int> GetFactors(int number)
		{
			return GetFactors(number, number);
		}
		static IEnumerable<int> GetFactors(int number, int check)
		{
			if (check > 0)
			{
				if (number % check == 0)
				{
					yield return check;
				}
				foreach (var f in GetFactors(number, --check))
				{
					yield return f;
				}
			}
		}
