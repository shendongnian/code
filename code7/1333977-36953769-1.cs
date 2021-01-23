	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void MyManagedDelegate(
		[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)]
		string[] values,
		int valueCount);
	[DllImport("NativeTemp", CallingConvention = CallingConvention.Cdecl)]
	public static extern void NativeLibCall(MyManagedDelegate callback);
	public static void Main()
	{
		NativeLibCall(PrintReceivedData);
	}
	public static void PrintReceivedData(string[] values, int valueCount)
	{
		foreach (var item in values)
			Console.WriteLine(item);
	}
	
