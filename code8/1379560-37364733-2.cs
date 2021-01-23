    class DBTableObjects
    {
        List<DBObject<int>> ls;
    
        public DBTableObjects()
        {
            ls = new List<DBObject<int>>();
        }
    
        protected void AddDBTableObject(DBObject<int> obj)
        {
            ls.Add(obj);
        }
    }
