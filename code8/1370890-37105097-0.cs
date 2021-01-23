    public class sometype {
	    public int readonlyProp{
			get;
		}
		public int normalProp {
			get;
			set;
		}
		public static int constField = 3;
		public readonly int readonlyField = 3;
		public int normalField = 3;
		public void test() {
			sometype test = new sometype() { readonlyProp = 3}; //		Doesn't work ->	Property or indexer is readonly
			sometype test1 = new sometype() { normalProp = 3 }; //		ok
			sometype test2 = new sometype() { constField = 3 };	//		Doesn't work ->	Static field or property
			sometype test3 = new sometype() { readonlyField = 3 }; //	Doesn't work ->	readonly field
			sometype test4 = new sometype() { normalField = 3 }; //		ok
		}
	}
