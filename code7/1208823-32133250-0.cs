    var messageType = typeof (SampleHandler1);
    //simple enough, Type -> SampleHandler1
    
    var genericType = typeof (IConsume<>).MakeGenericType(messageType);
    //so genericType is a Type -> IConsume<SampleHandler1>
    
    var genericArguments = genericType.GetGenericArguments();
    //there's only one, but Type[] { Type -> SampleHandler1 }
    var consumeMethod = genericType.GetMethod("Consume");
    //MethodInfo -> IConsume<SampleHandler1>.Consume(SampleHandler1)
    var constructorInfo = genericArguments[0].GetConstructor(Type.EmptyTypes);
    //ConstructorInfo -> SampleHandler1..ctor()
    var classObject = constructorInfo.Invoke(new object[] {});
    //new SampleHandler1()
    var argsx = new object[] {new SampleMessage {Name = "sample message"}};
    //object[] { SampleMessage }
    consumeMethod.Invoke(classObject, argsx);
    //((IConsume<SampleHandler1>)classObject).Consume( SampleMessage )
