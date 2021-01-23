	List<int> nonSelectedIndexes = new List<int>(Enumerable.Range(0, Password.Length));
	Random rand = new Random();
	if (!Password.Any(x => char.IsDigit(x))) { //does not contain digit
		char[] pass = Password.ToCharArray();
		int pos = nonSelectedIndexes[rand.Next(nonSelectedIndexes.Count)];
		nonSelectedIndexes.Remove(pos);
		pass[pos] = Convert.ToChar(rand.Next(10) + '0');
		Password = new string(pass);
	}
	if (!Password.Any(x => char.IsLower(x))) { //does not contain lower
		char[] pass = Password.ToCharArray();
		int pos = nonSelectedIndexes[rand.Next(nonSelectedIndexes.Count)];
		nonSelectedIndexes.Remove(pos);
		pass[pos] = Convert.ToChar(rand.Next(26) + 'a');
		Password = new string(pass);
	}
	if (!Password.Any(x => char.IsUpper(x))) { //does not contain upper
		char[] pass = Password.ToCharArray();
		int pos = nonSelectedIndexes[rand.Next(nonSelectedIndexes.Count)];
		nonSelectedIndexes.Remove(pos);
		pass[pos] = Convert.ToChar(rand.Next(26) + 'A');
		Password = new string(pass);
	}
    //And so on
    //Do likewise to any other condition 
