	Environment.SetEnvironmentVariable("line", Console.ReadLine());
	switch((int)Math.Floor(Double.Parse(Environment.GetEnvironmentVariable("line"))))
	{
		case -2:
			Console.Write("1.0");
			break;
		case -1:
			Console.Write("0.0");
			break;
		case 0:
			Console.Write(Environment.GetEnvironmentVariable("line"));
			break;
		default:
			if(Double.Parse(Environment.GetEnvironmentVariable("line")) > 0)
			{
				Console.Write("1.0");
			}else{
				Console.Write("2.0");
			}
			break;
	}
