	var formatter = new BinaryFormatter();
	var stream = new MemoryStream();
	
    //Serialise the object to memory
	formatter.Serialize(stream, testObject);
	
    //Reset the position back to start of stream!
	stream.Position = 0;
	
    //Deserialise back into a new object
	var newTestObject = (TestClass)formatter.Deserialize(stream);
