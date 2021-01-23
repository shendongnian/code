    public class TestTbl<DataType> : DBTableObjects<DataType>
    {
        public DBObject<DataType> _id;
        DBObject<string> _name;
        DBObject<string> _address;
    
        TestTbl()
        {
            _id = new DBObject<DataType>("id");
            AddDBTableObject(_id);
        }
    }
    
    public class DBTableObjects<DataType>
    {
        List<DBObject<DataType>> ls;
    
        public DBTableObjects()
        {
            ls = new List<DBObject<DataType>>();
        }
    
        protected void AddDBTableObject(DBObject<DataType> obj)
        {
            ls.Add(obj);
        }
    }
