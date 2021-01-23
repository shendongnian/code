    public class MyContext : DbContext
    {
        public MyContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
