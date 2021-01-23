        static private DBConnection _db=null;
        static public DBConnection Db
        {
            get
            {
                if (_db==null) Db=new DBConnection(); //You can also add connection or any initialisation
                return _db;
            }
            set { _db = value; }
        }
