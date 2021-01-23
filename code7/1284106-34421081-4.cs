    public class Proxy<T>
        {
            public ChannelFactory<T> Channel { get; set; }
        
            public Proxy()
            {
                Channel = new ChannelFactory<T>("endpoint");
            }
        
            public T CreateChannel()
            {
                return Channel.CreateChannel();
            }
    
            public void Execute(Action<T> action)
            {
                T proxy = CreateChannel();
        
                action(proxy);
        
                ((ICommunicationObject)proxy).Close();
            }
    
            public TResult Execute<TResult>(Func<T, TResult> function)
            {
                T proxy = CreateChannel();
            
                var result = function(proxy);
            
                ((ICommunicationObject)proxy).Close();
        
                return result;
            }
        }
