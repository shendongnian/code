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
        public bool SubscribeAsync<T>(Func<T, Task> eventHandler, string subscriptionId)
        {
            IMsgHandler<T> currMsgHandler = new MsgHandler<T>(eventHandler, subscriptionId);
            // Using the msgHandler allows to add a mediator between EasyNetQ and the actual callback function
            // The mediator can transmit the retried msg or choose to ignore it
            return _defaultBus.SubscribeAsync<T>(subscriptionId, currMsgHandler.InvokeMsgCallbackFunc).Queue != null;
        }
