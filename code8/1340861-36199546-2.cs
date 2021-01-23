	public abstract class MenuClass
	{
		public abstract void menu();
	}
	class Keyboard
	{
		//if you can pass class name
		public static string input<TClassName>() where TClassName : MenuClass, new()
		{
			new TClassName().menu();
		}
		//if you can not pass class name
		public static string input<TClassName>(TClassName obj) where TClassName : MenuClass, new()
		{
			new TClassName().menu(); //if you want to create new instance
            obj.menu(); //if you want to use already existing object
		}
	}
