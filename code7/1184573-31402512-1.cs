    List<OuputEntity> MyMethod<T>(T value) where T : Base 
    // adding this constraint ensures that T is of type that is derived from Base type
    {
       List<OutputEntity> result = new List<OutputEntity>();
       // some processing logic here like ...
       return result;
    }
    var resultForEntity1 = MyMethod<Entity1>();
    var resultForEntity2 = MyMethod<Entity2>();
