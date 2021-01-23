	void Main()
	{
		Byte X = 0x13;
		Byte Y = 0x6A;
		Byte Z = 0xA3;
		Byte W = 0x94;
		
		Foo foo = new Foo(X, Y, Z, W);
		uint i = foo;
		
		Foo bar = i;
		
		Console.WriteLine(X == bar.X);
		Console.WriteLine(Y == bar.Y);
		Console.WriteLine(Z == bar.Z);
		Console.WriteLine(W == bar.W);
	}
	
	[StructLayout(LayoutKind.Explicit)]
	public struct Foo
	{
		[FieldOffset(0)]
		public byte X;
	
		[FieldOffset(1)]
		public byte Y;
	
		[FieldOffset(2)]
		public byte Z;
	
		[FieldOffset(3)]
		public byte W;
		
		[FieldOffset(0)]
		public uint Value;
		
	
		public Foo(byte x, byte y, byte z, byte w) : this()
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}
		
		public static implicit operator Foo(uint value)
		{
			return new Foo(){ Value = value };
		}
		
		public static implicit operator uint(Foo foo)
		{
			return foo.Value;
		}
	}
