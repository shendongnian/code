	VelocityEngine velocityEngine = new VelocityEngine();
	velocityEngine.Init();
	VelocityContext context = new VelocityContext();
	context.Put("random", new Random());
	using (StringWriter sw = new StringWriter())
	{
		for (int i = 0; i < 5; i++)
		{
			velocityEngine.Evaluate(context, sw, "", "$random.Next(1, 100)\n");
		}
		Console.WriteLine(sw.ToString());
	}
