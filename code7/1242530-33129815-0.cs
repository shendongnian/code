    interface IMyData
    {
        DataTable GetMyData();
    }
    
    class MyData : IMyData
    {
        public DataTable GetMyData()
        {
             return Query.MyDataBase.ResultDT();
        }
    }
    class MyWork
    {
        private IMyData _myData;
        
        public MyWork(IMyData myData)
        {
            _myData = myData;
        }
        
        public int DoWork()
        {
            DataTable DT = _myData.GetMyData();
            return DT.Rows.Count;
        }
    }
