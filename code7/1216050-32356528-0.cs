    using System;
	public class Test
	{
		interface IChat
		{
			int Id { get; set; }
		}
		
		class User : IChat
		{
			public int Id { get; set; }
			public string first_name;
			public string last_name;
			public string username;
		}
		
		class GroupChat : IChat
		{
			public int Id { get; set; }
			public string title;
		}
		
		class MyClass
		{
			public IChat Chat { get; set; }
		}
		
		public static void Main()
		{
			MyClass foo = new MyClass();
			foo.Chat = new User();
			
			MyClass bar = new MyClass();
			bar.Chat = new GroupChat();
			
			if(foo.Chat.GetType() == typeof(User))
				Console.WriteLine("foo has User");
			else
				Console.WriteLine("foo has GroupChat");
				
			if(bar.Chat.GetType() == typeof(User))
				Console.WriteLine("bar has User");
			else
				Console.WriteLine("bar has GroupChat");
		}
	}
