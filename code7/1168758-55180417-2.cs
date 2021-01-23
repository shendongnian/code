        public void SetupMessageBroker(string givenSubscriptionId, bool enableRetry = false)
        {
            if (enableRetry)
            {
                _defaultBus = RabbitHutch.CreateBus(currentConnString,
                                                            serviceRegister => serviceRegister.Register<IErrorMessageSerializer>(serviceProvider => new RetryEnabledErrorMessageSerializer<IMessageType>(givenSubscriptionId))
                                                    );
            }
            else // EasyNetQ's DefaultErrorMessageSerializer will wrap error messages
            {
                _defaultBus = RabbitHutch.CreateBus(currentConnString);
            }
        }
