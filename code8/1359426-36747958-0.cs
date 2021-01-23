      using System.Runtime.InteropServices;
    
      public struct BIZARRE
      {
    	public int type;
    	[StructLayout(LayoutKind.Explicit)]
    	public struct AnonymousStruct
    	{
    		[FieldOffset(0)]
    		public int val;
    		[FieldOffset(0)]
    		public double val2;
    		[FieldOffset(0)]
    		public string name;
    	}
      }
