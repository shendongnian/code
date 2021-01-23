    public class MyClass
    {
        public int Id {get;set;}
        public int Other {get;set;}
    }
    
    // myClasses is a populated list <-- this needs to be checked.
    var result = myClasses.FirstOrDefault(x => x.Id == specificId && x.Other == specificOther);
