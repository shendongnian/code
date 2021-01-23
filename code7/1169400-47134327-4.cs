	Handlebars.RegisterHelper("ifCond", (writer, options, context, args) => {
		if (args.Length != 3)
		{
			writer.Write("ifCond:Wrong number of arguments");
			return;
		}
		if (args[0] == null || args[0].GetType().Name == "UndefinedBindingResult")
		{
			writer.Write("ifCond:args[0] undefined");
			return;
		}
		if (args[1] == null || args[1].GetType().Name == "UndefinedBindingResult")
		{
			writer.Write("ifCond:args[1] undefined");
			return;
		}
		if (args[2] == null || args[2].GetType().Name == "UndefinedBindingResult")
		{
			writer.Write("ifCond:args[2] undefined");
			return;
		}
		if (args[0].GetType().Name == "String")
		{
			var val1 = args[0].ToString();
			var val2 = args[2].ToString();
		
			switch (args[1].ToString())
			{
				case ">":
					if (val1.Length > val2.Length)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
				case "=":
				case "==":
					if (val1 == val2)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
				case "<":
					if (val1.Length < val2.Length)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
				case "!=":
				case "<>":
					if (val1 != val2)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
			}
		}
		else
		{
			var val1 = float.Parse(args[0].ToString());
			var val2 = float.Parse(args[2].ToString());
			switch (args[1].ToString())
			{
				case ">":
					if (val1 > val2)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
				case "=":
				case "==":
					if (val1 == val2)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
				case "<":
					if (val1 < val2)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
				case "!=":
				case "<>":
					if (val1 != val2)
					{
						options.Template(writer, (object)context);
					}
					else
					{
						options.Inverse(writer, (object)context);
					}
					break;
			}
		}
	});
