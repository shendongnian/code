                var timeOut=new TimeSpan(0, 10, 0);
                int timeOutInt = 2147483647;
                PropertyInfo channelFactoryProperty = proxyInstance.GetType().GetProperty("ChannelFactory");
            if (channelFactoryProperty == null)
            {
                throw new InvalidOperationException("There is no ''ChannelFactory'' property on the DomainClient.");
            }
            ChannelFactory factory = (ChannelFactory)channelFactoryProperty.GetValue(proxyInstance, null);
            factory.Endpoint.Binding.SendTimeout = timeOut;
            factory.Endpoint.Binding.OpenTimeout =  timeOut;
            factory.Endpoint.Binding.ReceiveTimeout = timeOut;
            factory.Endpoint.Binding.CloseTimeout = timeOut;
            BasicHttpBinding _binding = (BasicHttpBinding)factory.Endpoint.Binding;
            _binding.MaxBufferPoolSize = timeOutInt;
            _binding.MaxBufferSize = timeOutInt;
            _binding.MaxReceivedMessageSize = timeOutInt;
            _binding.OpenTimeout = timeOut;
