	var result = JsonConvert.DeserializeObject<Root>(jsonStr);
	Console.WriteLine(result.Cars.Car[0].Engines.Engine[0].Name == "1.2L");
	Console.WriteLine(result.Cars.Car[0].Engines.Engine[1].Name == "1.8L");
	Console.WriteLine(result.Cars.Car[1].Engines.Engine[0].Name == "2.2L");
	Console.WriteLine(result.Cars.Car[2].Engines == null);
