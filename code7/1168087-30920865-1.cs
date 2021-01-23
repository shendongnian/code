        private CustomBinding getWSHttpBinding()
        {
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.EstablishSecurityContext = false;
            binding.Security.Message.NegotiateServiceCredential = false;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            binding.MaxReceivedMessageSize = (1024 * 1024 * 10);
            BindingElementCollection elements = binding.CreateBindingElements();
            elements.Find<SecurityBindingElement>().EnableUnsecuredResponse = true;
            return new CustomBinding(elements);
        }
