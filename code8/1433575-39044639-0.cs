    var result = ((List<dynamic>)dropInfo.Data).Select(ConvertToMyEntityMethod).ToList();
    
    public static MyEntity ConvertToMyEntityMethod(dynamic obj)
    {
         return new MyEntity(){ SomeProperty = obj.SomeProperty };
    }
