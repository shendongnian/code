    var messageType = typeof(SampleMessage);
    var genericType = typeof(IConsume<>).MakeGenericType(messageType);
    var consumeMethod = genericType.GetMethod("Consume");
    var handlerType = typeof(SampleHandler1);
    var constructorInfo = handlerType.GetConstructor(Type.EmptyTypes);
    var classObject = constructorInfo.Invoke(new object[] {});
    var argsx = new object[] {new SampleMessage {Name = "sample message"}};
    consumeMethod.Invoke(classObject, argsx);
