    Attribute[] attributes = new Attribute[]
	{
		new AnimalTypeAttribute(Animal.Dog),
		new AnimalTypeAttribute(Animal.Cat),
		new AnimalTypeAttribute(Animal.Bird)
	};
	
	foreach (var attribute in attributes)
	{
		var type = attribute.GetType();
		var petProperty = type.GetProperty("Pet");
		var petValue = petProperty.GetValue(attribute);
		Console.WriteLine("Pet: {0}", petValue);
	}
    // Output:
    // Pet: Dog
    // Pet: Cat
    // Pet: Bird
