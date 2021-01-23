    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    public class Test
    {
        static void Main(string[] args)
        {
            using (var reader = new JsonTextReader(File.OpenText("test.json")))
            {            
                while (reader.Read())
                {
                    Console.WriteLine(reader.TokenType);                
                    Console.WriteLine(reader.Value);
                }
            }
        }
    }
