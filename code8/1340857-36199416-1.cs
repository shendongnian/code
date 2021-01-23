    // All classes passed into 'Keyboard.Input' should inherit this interface
	interface IMenu
	{
		public void menu();
	}
	class Foo : IMenu
	{
		public void test()
		{
            Keyboard.input(this);
		}
		public void menu()
		{
            Console.WriteLine("This is a menu");
		}
	}
