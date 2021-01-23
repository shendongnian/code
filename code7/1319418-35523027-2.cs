	void Main()
	{
		ClassA obj = new ClassA();
		Thread thread = new Thread(()=> 
		{
			Console.WriteLine ("About to execute MethodA");
			obj.MethodA("test", 2);
			Console.WriteLine ("Executed Method A");
		});
		thread.Start();
		thread.Join();
	}
	
	
	class ClassA
	{
		public void MethodA(string par1, int par2)
		{
			Console.WriteLine("Parameter " + par1 + " is passed with value " + par2);
		}
	}
