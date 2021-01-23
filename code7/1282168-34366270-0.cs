	public static class Test {
		public static Int64 add_if_in_range(Int64 basevalue, UInt64 newvalue) {
			if (basevalue < 0 & (newvalue >= (UInt64)Int64.MaxValue) ) {
				UInt64 ubase = (UInt64)(-basevalue);
				return checked((Int64)(newvalue-ubase));
			} else {
				return checked(basevalue + (Int64)newvalue);
			}		
		}
	}
	
	void Main()
	{
		// Some Test Cases:	
		Int64 l; UInt64 ul;
	
		l = Int64.MaxValue; ul = 100; // result causes overflow of Int64
		try {
			Console.WriteLine(Test.add_if_in_range(l, ul));
		} catch (OverflowException) {
			Console.WriteLine("Adding would cause an overflow");
		}
		
		l = Int64.MaxValue - 101; ul = 100; // result should be +9223372036854775806
		try {
			Console.WriteLine(Test.add_if_in_range(l, ul));
		} catch (OverflowException) {
			Console.WriteLine("Adding would cause an overflow");
		}
	
		l = Int64.MaxValue/2; ul = (UInt64)Int64.MaxValue/2; // result should be +9223372036854775806
		try {
			Console.WriteLine(Test.add_if_in_range(l, ul));
		} catch (OverflowException) {
			Console.WriteLine("Adding would cause an overflow");
		}
	
	
		l = Int64.MinValue; ul = 100; // result should be -9223372036854775708
		try {
			Console.WriteLine(Test.add_if_in_range(l, ul));
		} catch (OverflowException) {
			Console.WriteLine("Adding would cause an overflow");
		}
	
		l = Int64.MinValue; ul = UInt64.MaxValue; // result should be +9223372036854775807
		try {
			Console.WriteLine(Test.add_if_in_range(l, ul));
		} catch (OverflowException) {
			Console.WriteLine("Adding would cause an overflow");
		}
	
		l = Int64.MinValue; ul = UInt64.MaxValue-100; // result should be +9223372036854775807
		try {
			Console.WriteLine(Test.add_if_in_range(l, ul)); 
		} catch (OverflowException) {
			Console.WriteLine("Adding would cause an overflow");
		}
	
		l = Int64.MinValue + 1; ul = UInt64.MaxValue; // result causes overflow of Int64
		try {
			Console.WriteLine(Test.add_if_in_range(l, ul));
		} catch (OverflowException) {
			Console.WriteLine("Adding would cause an overflow");
		}
	
	}
	
