	private static int IntFromDecimalAscii(byte[] bytes)
	{
		int result = 0;
		// For each digit, add the digit's value times 10^n, where n is the
        // column number counting from right to left starting at 0.
		for(int i = 0; i < bytes.Length; ++i)
		{
            // ASCII digits are in the range 48 <= n <= 57. This code only
            // makes sense if we are dealing exclusively with digits, so
            // throw if we encounter a non-digit character
			if(bytes[i] < 48 || bytes[i] > 57)
			{
				throw new ArgumentException("Non-digit character present", "bytes");
			}
            // The bytes are in order from most to least significant, so
            // we need to reverse the index to get the right column number
			int exp = bytes.Length - i - 1;
            // Digits in ASCII start with 0 at 48, and move sequentially
            // to 9 at 57, so we can simply subtract 48 from a valid digit
            // to get its numeric value
			int digitValue = bytes[i] - 48;
            // Finally, add the digit value times the column value to the
            // result accumulator
			result += digitValue * (int)Math.Pow(10, exp);
		}
		return result;
	}
