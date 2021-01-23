     public class MyContext : DbContext 
        { 
            public MyContext() //constructor
            { 
                this.Configuration.LazyLoadingEnabled = false; 
            } 
        }
