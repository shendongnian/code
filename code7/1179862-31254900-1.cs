	var hull = new Hull();
	hull.Components.Add(new ComputerRoom { NumberOfCPUCores = 3 });
	hull.Components.Add(new System());
	hull.Components.Add(new Room());
	var serializer = new DataContractSerializer(typeof (Hull));
	using (var stream = File.Open("test.xml", FileMode.Create))
	{
		serializer.WriteObject(stream, hull);
	}
	Hull newHull;
	using (var stream = File.OpenRead("test.xml"))
	{
		newHull = serializer.ReadObject(stream) as Hull;
	}
	Console.WriteLine(newHull.Components.Count); //3
