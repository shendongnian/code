    public class MyContext : DbContext 
    { 
        public MyContext() 
        { 
            this.Configuration.ProxyCreationEnabled = false; 
        }  
    ....
    }
