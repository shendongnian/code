    public class MyDac
    {
        private readonly Database _db;
 
        public MyDac()
        {
            _db = new SqlDatabase("UserSelectedConnectionString");
        }
    }
