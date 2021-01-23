    class MyData
    {
        public string GameName { get; set; }
        public string Year { get; set; }
        public string ConsoleName { get; set; }
    }
    
    class MyDataClassMap : CsvClassMap<MyData>
    {
        public MyDataClassMap()
        {
            Map(x => x.GameName).Name("Column1");
            Map(x => x.Year).Name("Column2");
            Map(x => x.ConsoleName).Name("Column3");
        }
    }
