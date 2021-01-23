    public sealed class CustomSessionProvider : SessionStateStoreProviderBase
    {
        
        
        // Initialize the provider
        public override void Initialize(string name, NameValueCollection config)
        {
            try
            {
                Thread t = new Thread(() => MethodName(parameter1, parameter2));
                t.Start();
            }
            catch (Exception e) 
            { 
                //Exception executing the thread
                
            }
        }
		
		
}
