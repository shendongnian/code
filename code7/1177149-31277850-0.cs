    public class MyClass
    {
       ...
    }
    
    // in one part of the code, this class was serialized & deserialized using Json.Net:
    JsonConvert.SerializeObject(...);
    JsonConvert.DeserializeObject<MyClass>(...);
