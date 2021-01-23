    MyClass instance = new MyClass();
    MyClass newInstance = null;    
    using(ISerializer<MyClass> serializer = new MySerializer<MyClass>())
    {
        bytes[] bytes = serializer.Serialize(instance);    
        newInstance = serializer.DeSerialize(bytes);
    }
