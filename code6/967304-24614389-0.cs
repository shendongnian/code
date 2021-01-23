    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""name"": ""TPO"",
                ""columns"": [
                    ""ogc_fid"",
                    ""orderref"",
                    ""status"",
                    ""entityref"",
                    ""treetype"",
                    ""comments"",
                    ""orderyear"",
                    ""label"",
                    ""dist""
                ],
                ""data"": [
                    [
                        360,
                        ""07/1970/WR "",
                        ""Tree       "",
                        ""T6   "",
                        ""Chestnut"",
                        ""Position checked against Scanned Order 13/11/2008"",
                        1970,
                        ""479055.705,204698.514"",
                        33
                    ],
                    [
                        361,
                        ""07/1970/WR "",
                        ""Tree       "",
                        ""T7   "",
                        ""May"",
                        ""Position checked against Scanned Order 13/11/2008"",
                        1970,
                        ""479061.747,204685.09"",
                        35
                    ]
                ]
            }";
            var data = new JavaScriptSerializer().Deserialize<TPOData>(json);
            Console.WriteLine("name: " + data.name);
            Console.WriteLine();
            foreach (var row in data.data)
            {
                for (int i = 0; i < data.columns.Count; i++)
                {
                    Console.WriteLine(data.columns[i] + ": " + row[i]);
                }
                Console.WriteLine();
            }
        }
        public class TPOData
        {
            public string name;
            public List<string> columns;
            public List<List<object>> data;
        }
    }
