	// Starts with aa, ba, ba... instead of a, b, c. Probably wouldn't be hard
	// to fix but I abandoned this method because it's annoying to call using
	// string.Concat(...)
	public static IEnumerable<char> ToParamName(int number) {
		const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
		yield return characters[number % 26];
		number = number / 26;
		do {
			yield return characters[number % 36];
			number = number / 36 - 1;
		} while(number >= 0);
	}
	// Starts with a, b, c...aa, ba, ba but has collisions starting around 960
	public static IEnumerable<char> ToParamName(int number) {
		const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
		yield return characters[number % 26];
		number = number / 26;
		while(number > 0) {
			yield return characters[number % 36];
			number = number / 36 - 1;
		}
	}
