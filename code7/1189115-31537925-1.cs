    public static BaseObject ConvertJsonToClass<T>(string jsonString)
    {
        BaseObject obj = JsonConvert.DeserializeObject<BaseObject>(jsonString);
        switch (obj.TypeEnum)
        {
            case ObjectTypeEnum.Bird:
                return JsonConvert.DeserializeObject<Bird>(jsonString);
                break;
            case ObjectTypeEnum.Person:
                return JsonConvert.DeserializeObject<Person>(jsonString);
                break;
        }
        return obj;
    }
    public class BaseObject
    {
        public ObjectTypeEnum TypeEnum { get; set; }
    }
    public enum ObjectTypeEnum
    {
        Person = 1,
        Bird = 2
    }
    
    public class Person : BaseObject
    {
        public string PersonName { get; set; }
    
        private Person()
        {
            TypeEnum = ObjectTypeEnum.Person;
        }
    }
    public class Bird : BaseObject
    {
        public double Weight { get; set; }
    
        private Bird()
        {
            TypeEnum = ObjectTypeEnum.Bird;
        }
    
        
    }
