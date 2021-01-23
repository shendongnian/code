	public class Bot
	{
		public int a = 0;
		public int b;
        //If you try this it will not work
        //public int b = a;
		
		public Bot()
		{
            //This will work because once you create Bot, all fields will be initialized
			this.b = a;
		}
	}
    public static void Main()
	{
        //Once you create the class the Bot constructor will be called automatially
		Bot botty1 = new Bot();
	}
