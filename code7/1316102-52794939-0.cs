    using AutoMapper;
    
    public List<T> ReadData<T>(DataTable dt)
    {            
      return Mapper.DynamicMap<IDataReader, List<T>>(dt.CreateDataReader());                        
    }
