    public static void MultiplyDigitArrays(int[] lhs, int[] rhs, int[] result)
	{        
		var n1 = BigInteger.Parse(string.Join("", lhs));
		var n2 = BigInteger.Parse(string.Join("", rhs));
		var resultBi = BigInteger.Multiply(n1, n2);		
		Array.Clear(result, 0, result.Length);
		var stResult = resultBi.ToString().PadLeft(result.Length, '0');
		for(int i = 0; i < stResult.Length; i++)
		{
			result[(stResult.Length-1)-i] = int.Parse(stResult[i].ToString());
		}
	}
