	public static string MultiplyBigNumbers(string lhs, string rhs)
	{        
		var n1 = BigInteger.Parse(lhs);
		var n2 = BigInteger.Parse(rhs);
		return BigInteger.Multiply(n1, n2).ToString();		
	}
