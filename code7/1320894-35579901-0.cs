    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    namespace ExpandoObject
    {
        class Program
        {
            static void Main(string[] args)
            {
                string stringObj;
                stringObj = "{\"op\": \"add\", \"path\": \"/a/b\", \"value\": \"foo\"}";
                Console.WriteLine(JsonConvert.SerializeObject(GetObjectPatchResult(stringObj)));
                stringObj = "{\"op\": \"add\", \"path\": \"/a/b/c/d/e/f/g/h/i/j\", \"value\": \"foo\"}";
                Console.WriteLine(JsonConvert.SerializeObject(GetObjectPatchResult(stringObj)));
            }
    
            private static object GetObjectPatchResult(string param)
            {
                dynamic expando = new System.Dynamic.ExpandoObject();
                var result = (IDictionary<string, object>)expando;
                var parchObject = JsonConvert.DeserializeObject<PatchObject>(param);
                var level = result;
                int i = 0;
                foreach (var path in parchObject.Path.Split('/'))
                {
                    i++;
                    if (string.IsNullOrEmpty(path)) continue;
                    dynamic pathExpando = new System.Dynamic.ExpandoObject();
                    level[path] = (IDictionary<string, object>)pathExpando;
                    if (i < parchObject.Path.Split('/').Count())
                    {
                        level = (IDictionary<string, object>)level[path];
                    }
                    else
                    {
                        level[path] = parchObject.Value;
                    }
                }
                return result;
            }
        }
        
        public class PatchObject
        {
            public string Op { get; set; }
            public string Path { get; set; }
            public string Value { get; set; }
        }
    }
