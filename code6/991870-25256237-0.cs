	var c = 'א';
	c.Dump();
	char.IsUpper(c).Dump("is upper");    // False
	char.IsLower(c).Dump("is lower");    // False
	char.IsLetterOrDigit(c).Dump("is letter or digit"); // True
	char.IsNumber(c).Dump("is Number");  // False
