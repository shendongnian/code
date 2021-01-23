    //your POCO class here
    class Order
    {
        public virtual Client Client { get; set; }
    }
    
    class Client
    {
        public string Name { get; set; }
    }
    //the framework uses something like this
    class Order_Proxy : Order
    {
        public override Client Client
        {
            get 
            { 
                //return Client_Proxy when you access this property
                //the query executes when accessing
            }
            set { /*blabla*/ }
        }            
    }
    class Client_Proxy : Client
    {
        //a proxy wrapper like Order_Proxy
    }
