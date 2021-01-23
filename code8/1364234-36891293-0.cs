    public interface IDataModelFactory<T> where T:ModelBase
    {
        int GetLastTempId();
    }
    
    public Model1Factory : IDataModelFactory<Model1>
    {
        public int GetLastTempId()
        {
            // logic for Model1 
        }
    }
    
    public Model2Factory : IDataModelFactory<Model2>
    {
        public int GetLastTempId()
        {
            // logic for Model2
        }
    }
