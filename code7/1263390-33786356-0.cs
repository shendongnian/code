    private void Foo(dynamic objectWithTypeToClone)
    {
        dynamic instanceOfType = Activator.CreateInstance(objectWithTypeToClone.GetType()); 
        instanceOfType.SomeProperty = ObjectId.GenerateNewId(); //ignore the right side
    }
