	public class Shift
	{
		public string Decrypt(string cipherString, int shift)
		{
			var alphabet =
				Enumerable
				.Concat(
					Enumerable.Range((int)'a', 26),
					Enumerable.Range((int)'A', 26))
				.Select(i => (char)i)
				.ToArray();
		
			var map =
				alphabet
					.Zip(
						alphabet.Concat(alphabet).Concat(alphabet).Skip(alphabet.Length + shift),
						(c0, c1) => new { c0, c1 })
					.ToDictionary(x => x.c0, x => x.c1);
					
			return String.Join("", cipherString.Select(x => map.ContainsKey(x) ? map[x] : x));
		}
	}
