    using(var context = new MyContext(DbHelper.GetConnectionString()))
    {
    
    }
    
    public static class DbHelper
    {
        public static string GetConnectionString()
        {
            //some logic to get the corrosponding connection string
            // which you are wanting  this could be based of url
        }
    }
