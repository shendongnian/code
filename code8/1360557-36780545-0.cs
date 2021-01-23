    protected CustomBinding GetCustomBinding()
        {
            var customBinding = new CustomBinding() { Name = "CustomBinding" };
            customBinding.Elements.Add(new TextMessageEncodingBindingElement() { MessageVersion = MessageVersion.Soap11 });
            var securityBindingElement = SecurityBindingElement.CreateUserNameOverTransportBindingElement();
            securityBindingElement.AllowInsecureTransport = true;
            securityBindingElement.EnableUnsecuredResponse = true;
            securityBindingElement.IncludeTimestamp = false;
            customBinding.Elements.Add(securityBindingElement);
            customBinding.Elements.Add(new HttpTransportBindingElement());
            return customBinding;
        }
