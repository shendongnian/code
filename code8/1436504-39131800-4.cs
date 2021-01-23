    using System;
    using Newtonsoft.Json;
    
    namespace WpfApplication3
    {
        public partial class MainWindow
        {
            private readonly string json = @"
    {  
       ""Id"":""1405de4d-2823-43b4-8dba-66c2714bc7f"",
       ""Name"":""Sports/Boxing"",
       ""Started"":""\/Date(1472064057630)\/"",
       ""DurationMilliseconds"":227.2,
       ""MachineName"":""RED"",
       ""CustomLinks"":null,
       ""Root"":{  
          ""Id"":""88ada251-cff1-4eb7-bc47-2e6d366616a63"",
          ""Name"":""http://localhost:80/PDC/Sports/Boxing"",
          ""DurationMilliseconds"":227.2,
          ""StartMilliseconds"":0,
          ""Children"":[  
             {  
                ""Id"":""dbf36d18-8abd-43f1-ae9b-640cb3d77a87"",
                ""Name"":""Red Eagle"",
                ""DurationMilliseconds"":212,
                ""StartMilliseconds"":15.1,
                ""Children"":[  
                   {  
                      ""Id"":""dbd7018d-421d-42bd-b0e5-fd3e9462cca0"",
                      ""Name"":""Blue Eagle"",
                      ""DurationMilliseconds"":106.8,
                      ""StartMilliseconds"":120.4,
                      ""Children"":[  
                         {  
                            ""Id"":""c86199e0-d12b-4bd0-90ea-9f15a2618160"",
                            ""Name"":""True Eagle"",
                            ""DurationMilliseconds"":0.3,
                            ""StartMilliseconds"":226.9,
                            ""Children"":null,
                            ""CustomTimings"":null
                         }
                      ],
                      ""CustomTimings"":null
                   }
                ],
                ""CustomTimings"":null
             }
          ],
          ""CustomTimings"":null
       },
       ""ClientTimings"":null,
       ""User"":""::1"",
       ""Storage"":null
    }";
    
            public MainWindow()
            {
                InitializeComponent();
                var o = JsonConvert.DeserializeObject<MyObject>(json);
            }
        }
    
        public class Child
        {
            [JsonProperty("Id")]
            public string Id { get; set; }
    
            [JsonProperty("Name")]
            public string Name { get; set; }
    
            [JsonProperty("DurationMilliseconds")]
            public double DurationMilliseconds { get; set; }
    
            [JsonProperty("StartMilliseconds")]
            public double StartMilliseconds { get; set; }
    
            [JsonProperty("Children")]
            public Child[] Children { get; set; }
    
            [JsonProperty("CustomTimings")]
            public object CustomTimings { get; set; }
        }
    
        public class MyObject
        {
            [JsonProperty("Id")]
            public string Id { get; set; }
    
            [JsonProperty("Name")]
            public string Name { get; set; }
    
            [JsonProperty("Started")]
            public DateTime Started { get; set; }
    
            [JsonProperty("DurationMilliseconds")]
            public double DurationMilliseconds { get; set; }
    
            [JsonProperty("MachineName")]
            public string MachineName { get; set; }
    
            [JsonProperty("CustomLinks")]
            public object CustomLinks { get; set; }
    
            [JsonProperty("Root")]
            public Child Root { get; set; }
    
            [JsonProperty("ClientTimings")]
            public object ClientTimings { get; set; }
    
            [JsonProperty("User")]
            public string User { get; set; }
    
            [JsonProperty("Storage")]
            public object Storage { get; set; }
        }
    }
