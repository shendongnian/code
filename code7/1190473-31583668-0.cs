    public static void UpdateStatus<TSubscriber, TMessage>(object status, string token)
            {
                if (!(status.GetType() == typeof(TMessage)))
                {
                    throw new ArgumentException("Message type is different than the second type argument");
                }
                
                var subscribersWithCorrespondingType = (from subscriber in _subscribers
                                   where (subscriber.GetType().GenericTypeArguments[0] == typeof(TSubscriber)) &&
                                          (subscriber.GetType().GenericTypeArguments[1] == typeof(TMessage))
                                   select subscriber).ToList();
    
                var subscribers = (from subscriber in subscribersWithCorrespondingType
                                   where ((Subscribtion<TSubscriber, TMessage>) subscriber).Token == token
                                   select subscriber).ToList();
    
                foreach (var subscriber in subscribers)
                {
                    ((Subscribtion<TSubscriber, TMessage>)subscriber).SubscriberAction((TMessage)status);
                }
            }
