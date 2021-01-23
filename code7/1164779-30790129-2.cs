    namespace MyCodeFirstProject 
    {     
        public class MyDBContext: DbContext     
        {         
            public MyDBContext() : 
                base("Data Source=SQLServerAddress;Integrated Security=SSPI;Initial Catalog=yourdbName") {}
        }
    }  
