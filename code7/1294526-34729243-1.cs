	static void Main(string[] args)
	{
		using (var db = new FooContext())
		{
			var myFoo = new Foo {Id = 1002, Descr = "Test"};
			db.Add(myFoo);
			db.SaveChanges();
		}
		using (var db = new FooContext())
		{
			var myFoo = db.Foos.FirstOrDefault(x => x.Id == 1002);
			Console.WriteLine($"id = {myFoo?.Id}, descrip = {myFoo?.Descr}");
		}
	}
