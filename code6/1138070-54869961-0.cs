	[Flags]
	public enum MyEnum
	{
		None = 0,
		Value1 = 1 << 0,
		Value2 = 1 << 1,
		Value3 = 1 << 2,
		Value4 = 1 << 3,
		//so on
	}
	public abstract class MyClass
	{
		public MyEnum myEnum = MyEnum.None;
		public void testing()
		{
			// Initialize with two flags using bitwise OR.
			MyEnum workingFlags = MyEnum.Value1 | MyEnum.Value3;
			// Set an additional flag using bitwise OR.
			workingFlags= workingFlags| MyEnum.Value4;
			// workingFlags: Value1, Value3, Value4
			// Remove a flag using bitwise XOR.
			workingFlags = workingFlags ^ MyEnum.Value3;
			// workingFlags: Value1, Value4
			// Test value of flags using bitwise AND.
			bool test = (workingFlags & MyEnum.Value3) == MyEnum.Value3;
			// test = true;
		}
	}
	public abstract class Level
	{
		public MyEnum LEVEL0 = MyEnum.Value1 | MyEnum.Value2;
		public MyEnum LEVEL1 = MyEnum.Value3 | MyEnum.Value4;
	}
