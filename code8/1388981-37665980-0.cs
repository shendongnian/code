        private SoapServerMessage CreateSoapServerMessage(
            SoapMessageStage stage,
            string action,
            SoapHeaderCollection headers)
        {
            var typ = typeof(SoapServerMessage);
            // Create an instance:
            var constructorInfo = typ.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null, new[] { typeof(SoapServerProtocol) }, null);
            var message = (SoapServerMessage)constructorInfo.Invoke(new object[] { CreateSoapServerProtocol(action) });
            // Set stage:
            var stageField = typ.BaseType.GetField("stage", BindingFlags.NonPublic | BindingFlags.Instance);
            stageField.SetValue(message, stage);
            // Set headers:
            var headersField = typ.BaseType.GetField("headers", BindingFlags.NonPublic | BindingFlags.Instance);
            headersField.SetValue(message, headers);
            return message;
        }
        private SoapServerProtocol CreateSoapServerProtocol(string action)
        {
            var typ = typeof(SoapServerProtocol);
            // Create an instance:
            var constructorInfo = typ.GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null, Type.EmptyTypes, null);
            var protocol = (SoapServerProtocol)constructorInfo.Invoke(null);
            // Set serverMethod:
            var serverMethodField = typ.GetField("serverMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            serverMethodField.SetValue(protocol, CreateSoapServerMethod(action));
            return protocol;
        }
        private SoapServerMethod CreateSoapServerMethod(string action)
        {
            var typ = typeof(SoapServerMethod);
            // Create an instance:
            var method = new SoapServerMethod();
            // Set action:
            var actionField = typ.GetField("action", BindingFlags.NonPublic | BindingFlags.Instance);
            actionField.SetValue(method, action);
            return method;
        }
