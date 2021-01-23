    public class A {
		public void test() {
			B.testB(this);
		}
	}
	public class B {
		public static void testB(object sender) {
			Console.WriteLine(sender.GetType().Name);
		}
	}
    //To call
    A a = new A();
	a.test();
