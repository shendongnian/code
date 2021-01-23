    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ThierCode
    {
        public class MyTableQuery : YourLibrary.IMultiTableQuery
        {
    
            public Dictionary<string, string> MethodNameAndSql { get; set; }
    
            public void PopulateMyObjects(IDataRecord dr)
            {
                MyObject o = new MyObject();
                o.Name = dr["Name"].ToString();
                this.MyObjects.Add(o);
            }
    
            public List<MyObject> MyObjects { get; set; }
        }
    
        public class MyObject
        {
            public string Name { get; set; }
        }
    }
    
    namespace YourLibrary
    {
        public interface IMultiTableQuery
        {
            public Dictionary<string, string> MethodNameAndSql { get; set; }
        }
        public class Repo<T> where T : IMultiTableQuery
        {
            public void GetData(T inputClass)
            {
                Type type = typeof(T);
                
    
                foreach (var kvp in inputClass.MethodNameAndSql)
                {
                    string sql = kvp.Value;
                    //run sql and get datareader
    
                    //get the populate method back from the dictionary 
                    MethodInfo methodInfo = type.GetMethod(kvp.Key);
                    while (reader.Read())
                    {
                        // execute via reflection
                        methodInfo.Invoke(inputClass, reader);
                    }
    
                }
            }
    
        }
    }
