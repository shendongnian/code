    var result = ((List<dynamic>)dropInfo.Data).Select(ConvertToMyEntityMethod).ToList();
    
    public static MyEntity ConvertToMyEntity(dynamic obj)
    {
         return new MyEntity(){ SomeIntProperty = (int)obj.SomeIntProperty };
    }
