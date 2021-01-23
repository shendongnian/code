	private static void Run()
	{
			var ctx = new IronJS.Hosting.CSharp.Context();
			dynamic a = ctx.Execute("var a = (((2+5)*1000)/((30-20)*7)); a;");
			Console.WriteLine(a);
	}
