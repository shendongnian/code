    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string result = @"
    {  
       'values':{  
       'value':[
         {  
            'value_1':'aaaaaa',
            'value_2':'aaaaaa',
            'value_3':'aaaaaa'
         },
         {  
            'value_1':'bbbbbb',
            'value_2':'bbbbbb',
            'value_3':'bbbbbb'
         }
      ]
      }
    }";
    
                var myData = JsonConvert.DeserializeObject<MyContent<MyData>>(result);
            }
        }
    
        public class MyContent<T> where T : class
        {
    
            [JsonProperty("values")]
            public DataResponse<T> Values { get; set; }
        }
    
        [Serializable]
        public class MyData
        {
            public string value_1 { get; set; }
            public string value_2 { get; set; }
            public string value_3 { get; set; }
        }
    
        public interface IDataResponse<T> where T : class
        {
            List<T> Data { get; set; }
        }
    
        public class DataResponse<T> : IDataResponse<T> where T : class
        {
            [JsonProperty("value")]
            public List<T> Data { get; set; }
        }
    }
