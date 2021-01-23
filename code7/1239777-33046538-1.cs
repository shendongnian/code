	string a1 = "B91EFEBFBDBDBFEFF39ABEE";
	string a2 = "000FFFFFFFFFFFFFFFFFEEE";
	BigInteger num1 = BigInteger.Parse(a1, NumberStyles.HexNumber);
	BigInteger num2 = BigInteger.Parse(a2, NumberStyles.HexNumber);
	BigInteger sum = num1 + num2;
	Console.WriteLine(sum.ToString("X"));
	Console.WriteLine((sum - num2).ToString("X")); //gets a1
