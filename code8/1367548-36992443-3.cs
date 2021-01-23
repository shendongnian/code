    public static Dictionary<Type, Action<EventMessage>> GenerateHandlerDelegatesFromTypeLists(Dictionary<Type, List<Type>> handlerTypesByMessageType)
    {
        var handlersByMessageType = new Dictionary<Type, Action<EventMessage>>();
        foreach (var messageType in handlerTypesByMessageType.Keys)
        {
            var handlerTypeList = handlerTypesByMessageType[messageType];
            if (handlerTypeList.Count < 1)
                throw new NotImplementedException("No handlers for that type");
            var method =
                new DynamicMethod(
                    "handler_" + messageType.Name,
                    null,
                    new [] { typeof(EventMessage) });
            var gen = method.GetILGenerator();
            foreach (var handlerType in handlerTypeList)
            {
                var handlerCtor = handlerType.GetConstructor(new Type[0]);
                var handlerMethod =
                    handlerType.GetMethod("Handle", new Type[] { messageType });
                // create an object of the handler type
                gen.Emit(OpCodes.Newobj, handlerCtor);
                // load the EventMessage passed as an argument
                gen.Emit(OpCodes.Ldarg_0);
                // call the handler object's Handle method
                gen.Emit(OpCodes.Callvirt, handlerMethod);
            }
            gen.Emit(OpCodes.Ret);
            var del = (Action<EventMessage>)method.CreateDelegate(
                typeof(Action<EventMessage>));
            handlersByMessageType[messageType] = del;
        }
    }
