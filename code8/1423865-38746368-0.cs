        protected void BindEvents(WebControl ctrl, string methodName, string eventType)
        {
            System.Reflection.EventInfo eventInfo = ctrl.GetType().GetEvent(eventType);
            var delegateType = eventInfo.EventHandlerType.GetMethod("Invoke");
            var methodInfo = this.GetType().GetMethod(methodName);
            var parameters = delegateType.GetParameters();
            if (parameters.Length!=2)
                throw new NotImplementedException(); // Can make switch and multiple CreateAction methods to handle
            var genericCreateAction = this.GetType().GetMethod("CreateAction2");
            var parameterTypes = parameters.Select(o => o.ParameterType).ToArray<Type>();
            var createAction = genericCreateAction.MakeGenericMethod(parameterTypes);
            var action = (Delegate)createAction.Invoke(this, new object[] { methodInfo, eventType });
            var properTypeAction = Delegate.CreateDelegate(eventInfo.EventHandlerType, action.Target, action.Method);
            eventInfo.AddEventHandler(ctrl, properTypeAction);
        }
        public Action<T1, T2> CreateAction2<T1, T2>(MethodInfo methodInfo, string eventName)
        {
            return (Action<T1, T2>)((p1, p2) => { methodInfo.Invoke(this, new object[] { p1, p2, eventName }); });
        }
