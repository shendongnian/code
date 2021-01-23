	Model model = new Model();
	Model modelWithValue = new Model { Result = 1};
	Model modelThatIsNull = null;
	Int32 result = model?.Result ?? -1;
	Int32 resultWithValue = modelWithValue?.Result ?? -1;
	Int32 resultWithNull = modelThatIsNull?.Result ?? -2;
	Console.WriteLine(result); // Prints -1
	Console.WriteLine(resultWithValue); // Prints 1
	Console.WriteLine(resultWithNull); // Prints -2
