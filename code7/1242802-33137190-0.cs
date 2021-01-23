    public int ValueTest(int iValue)
    {
        if ((iValueTwo > 84) && (iValueTwo < 184) {
			return iValue;
		}
		return 0;
    }
    static int Main(string[] args)
    {
		int a=50;
		int b=51;
		
        int iResult = 0;
		iResult = ValueTest(a) + ValueTest(b);
		Console.WriteLine("Result is: ", iResult);
        return 0;
    }
