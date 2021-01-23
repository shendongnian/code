            CancellationTokenSource cts = new CancellationTokenSource();
            Action test = CancelMethod;
            CancellationTokenRegistration = cts.Token.Register(test);
            var fieldInfo = typeof(CancellationTokenRegistration).GetField("m_callbackInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            object fieldValue = fieldInfo.GetValue(CancellationTokenRegistration);
            var callbackFieldInfo = fieldValue.GetType().GetField("Callback", BindingFlags.Instance | BindingFlags.NonPublic);
            var callbackValue = callbackFieldInfo.GetValue(fieldValue);
            var stateForCallbackFieldInfo = fieldValue.GetType().GetField("StateForCallback", BindingFlags.Instance | BindingFlags.NonPublic);
            var stateForCallbackValue = stateForCallbackFieldInfo.GetValue(fieldValue);
            // stateForCallbackValue == CancelMethod; if Token.Register is called with one of the Action<object> arguments 
            // callbackValue == CancelMethod
            
            private void CancelMethod()
            {
                throw new System.NotImplementedException();
            }
