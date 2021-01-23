    public void test_json(int _num, Test_Class _obj)
	{
		JsonSerializer serializer = new JsonSerializer();
		MemoryStream stream = new MemoryStream();
		StreamWriter writer = new StreamWriter(stream);
		JsonTextWriter jsonWriter = new JsonTextWriter(writer);
		serializer.Serialize(jsonWriter, _obj);
		jsonWriter.Flush();
		Stopwatch stopWatch = new Stopwatch ();
		stopWatch.Start ();
		while (_num > 0) {
			_num -= 1;
			stream.Position = 0;
			StreamReader reader = new StreamReader(stream);
			JsonTextReader jsonReader = new JsonTextReader(reader);
			Test_Class deserialised_object = serializer.Deserialize<Test_Class>(jsonReader);
		}
		stopWatch.Stop ();
		TimeSpan ts = stopWatch.Elapsed;
		string elapsedTime = String.Format ("{0:00}:{1:00}:{2:00}.{3:00}",
			ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
		
		print ("json read: " + elapsedTime);
	}
