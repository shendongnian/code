	public interface ImyClass {
		int a { get; set; }
		int b { get; set; }
		void method_01();
	}
	class myClass01 : ImyClass { //your special interface implementation for myClass01
		public int a { get; set; }
		public int b { get; set; }
		public void method_01() { }
		public void method_A() { }
	}
	class myClass02 : ImyClass {  //your special interface implementation for myClass02
		public int a { get; set; }
		public int b { get; set; }
		public void method_01() { }
		public void method_B() { }
	}
