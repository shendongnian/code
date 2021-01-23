    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json.Linq;
    
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = @"{
      ""batchcomplete"": """",
      ""query"": {
        ""normalized"": [
          {
            ""from"": ""program"",
            ""to"": ""Program""
          }
        ],
        ""pages"": {
          ""23771"": {
            ""pageid"": 23771,
            ""ns"": 0,
            ""title"": ""Program"",
            ""revisions"": [
              {
                ""contentformat"": ""text/x-wiki"",
                ""contentmodel"": ""wikitext"",
                ""*"": ""the page content is too long to reasonably post here""
              }
            ]
          }
        }
      }
    }";
                var json = JObject.Parse(str);
                var pages = json["query"]["pages"].Values().First();
    
                Console.WriteLine(pages["title"]);
                Console.WriteLine(pages["revisions"][0]["*"]);
            }
        }
    }
