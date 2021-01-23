    // Temp Data Struct
	class DataItem{
		public string username;
		}
    //Valid Json look like : {"username": "1"}
    //Valid Json must be double quoted again when assigned to string var
    // or escaped if you want 'valid' Json to be passed to the FromJson method
    //string json = "{\"username\": \"1\"}"; or
	
    string json = @"{""username"": ""1""}";
	DataItem deserialized = JsonUtility.FromJson<DataItem>(json);
	Debug.Log("Deserialized "+ deserialized.username);
