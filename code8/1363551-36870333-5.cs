    [JsonConverter(typeof(FooClassDtoConverter))]
    public class FooClassDto
    {
       int OtherProperties {get;set;}
       List<T> FooCollection {get;set;}
    }
