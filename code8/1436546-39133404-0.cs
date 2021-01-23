    using Newtonsoft.Json;
    
    namespace WpfApplication3
    {
        public partial class MainWindow
        {
            private readonly string json = @"
    {
        ""x"": 6,
        ""y"": 6,
        ""information"": [
            {
                ""x"": 0,
                ""y"": 0,
                ""info"": ""First item"",
                ""info2"": 1
            },
            {
                ""x"": 1,
                ""y"": 3,
                ""info"": ""Second item"",
                ""info2"": 3
            },
            {
                ""x"": 3,
                ""y"": 4,
                ""info"": ""Third item"",
                ""info2"": 2
            }
        ]
    }";
    
            public MainWindow()
            {
                InitializeComponent();
    
                var o = JsonConvert.DeserializeObject<SampleResponse1>(json);
                var array = new IInformation[o.X, o.Y];
                foreach (var i in o.Information)
                {
                    array[i.X, i.Y] = i;
                }
            }
        }
    
        internal class SampleResponse1
        {
            [JsonProperty("x")]
            public int X { get; set; }
    
            [JsonProperty("y")]
            public int Y { get; set; }
    
            [JsonProperty("information")]
            public Information[] Information { get; set; }
        }
    
        internal class Information : IInformation
        {
            [JsonProperty("x")]
            public int X { get; set; }
    
            [JsonProperty("y")]
            public int Y { get; set; }
    
            #region IInformation Members
    
            [JsonProperty("info")]
            public string Info { get; set; }
    
            [JsonProperty("info2")]
            public int Info2 { get; set; }
    
            #endregion
        }
    
        internal interface IInformation
        {
            string Info { get; set; }
            int Info2 { get; set; }
        }
    }
