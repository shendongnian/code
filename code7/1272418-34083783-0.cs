    public class Operation
    {
        public bool EventFired 
        {
            get { return _eventFired; }
        }
        private bool _eventFired = false;
        public void Execute(object source, string EventName)
        {
            EventInfo eventInfo = source.GetType().GetEvent(EventName);
            Delegate handler = null;
            Type delegateHandler = eventInfo.EventHandlerType;
            MethodInfo invokeMethod = delegateHandler.GetMethod("Invoke");
            ParameterInfo[] parms = invokeMethod.GetParameters();
            Type[] parmTypes = new Type[parms.Length + 1];
            parmTypes[0] = this.GetType();  //First parameter is this class type.
            for (int i = 0; i < parms.Length; i++)
                parmTypes[i + 1] = parms[i].ParameterType;
            DynamicMethod customMethod = new DynamicMethod
                                        (
                                            "TempMethod",
                                            invokeMethod.ReturnType,
                                            parmTypes
                                        );
            MethodInfo inf = typeof (Operation).GetMethod("SetFlag", BindingFlags.Instance | BindingFlags.Public);
            ILGenerator ilgen = customMethod.GetILGenerator();
            ilgen.Emit(OpCodes.Ldarg_0);
            ilgen.Emit(OpCodes.Call, inf);
            ilgen.Emit(OpCodes.Ret);
            handler = customMethod.CreateDelegate(delegateHandler, this);      
                                                                               
            eventInfo.AddEventHandler(source, handler);
        }
        /// <summary>Signals that the event has been raised.</summary>
        public void SetFlag()
        {
            _eventFired = true;
        }
    }
