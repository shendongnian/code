    class MainClass
    {
        public static void Main(string [] args)
        {
            var a = Assembly.GetExecutingAssembly();
            Dictionary<Type, List<Type>> handlerTypesByMessageType = new Dictionary<Type, List<Type>>();
            // find all types in the assembly that implement IEventHandler<T>
            for some value(s) of T
            foreach (var t in a.GetTypes())
            {
                foreach (var iface in t.GetInterfaces())
                {
                    if (iface.GetGenericTypeDefinition() == typeof(IEventHandler<>))
                    {
                        var messageType = iface.GetGenericArguments()[0];
                        if (!handlerTypesByMessageType.ContainsKey(messageType))
                            handlerTypesByMessageType[messageType] = new List<Type>();
                        handlerTypesByMessageType[messageType].Add(t);
                    }
                }
            }
            // get list of events
            var messages = new List<EventMessage> {
                new NewRecordCreated("one"),
                new RecordUpdated("two"),
                new RecordUpdated("three"),
                new NewRecordCreated("four"),
                new RecordUpdated("five"),
            };
            // process all events
            foreach (var msg in messages)
            {
                var messageType = msg.GetType();
                if (!handlerTypesByMessageType.ContainsKey(messageType))
                {
                    throw new NotImplementedException("No handlers for that type");
                }
                if (handlerTypesByMessageType[messageType].Count < 1)
                {
                    throw new NotImplementedException("No handlers for that type");
                }
                // look up the handlers for the message type
                foreach (var handlerType in handlerTypesByMessageType[messageType])
                {
                    var handler = Activator.CreateInstance(handlerType);
                    // look up desired method by name and parameter type
                    var handlerMethod = handlerType.GetMethod("Handle", new Type[] { messageType });
                    handlerMethod.Invoke(handler, new object[]{msg});
                }
            }
        }
    }
