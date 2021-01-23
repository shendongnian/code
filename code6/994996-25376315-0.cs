    public interface IDataHandler
    {
       IDictionary<string,string> GetData();
       void SetData(string key,string value);
    }
    public class MyDataHandler : IDataHandler
    {
       public IDictionary<string,string> GetData()
       {
           return CacheManager.GetData("ConfigcacheKey") as IDictionary<string,string>;
       }
       public void SetData(string key,string value)
       {
           var data = GetData() ?? new Dictionary<string,string();
           if(data.ContainsKey(key)) data[key] = value;
           else data.Add(key,value);
           CacheManager.Add("ConfigcacheKey", data);
          
           // HERE write an async method to save the key,value in database or XML file
       }
    }
