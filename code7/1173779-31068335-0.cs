    List<MyClass> deserializedObjects = new List<MyClass>();
    using(var reader = new StreamReader(pathToFile)){
        while(!reader.EndOfStream){
            deserializedObjects.Add(JsonDeserialize<MyClass>(reader.ReadLine()));
        }
    }
