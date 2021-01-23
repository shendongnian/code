    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            
            static void Main(string[] args)
            {
                string json = @"{
    ""methods"": {
        ""password.2"": {
          ""title"": ""Password CustomerID"",
          ""type"": ""password""
        },
        ""ubikey.sms.1"": {
          ""title"": ""SMS"",
          ""type"": ""stepup"",
          ""password"": ""password.2"",
          ""stepUp"": ""sms""
        },
        ""tupas.test.1"": {
          ""title"": ""TUPAS Emulator"",
          ""type"": ""proxy""
        }
      }
    }";
    
                Dictionary<string, Dictionary<String,Dictionary<String,String>>> values = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<String,Dictionary<String,String>>>>(json);
            }
    
            
        }
    }
