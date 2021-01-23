    public static class MyStuff
    {
        //A property
        public static string SomeVariable { get; set; }
        public static List<string> SomeListOfStuff { get; set; }
        //Init your variables in here:
        static MyStuff()
        {
            SomeVariable = "blah";
            SomeListOfStuff = new List<string>();
        }
		public static async Task<string> DoAThing()
		{
			//Do your async stuff in here
		}
    }
