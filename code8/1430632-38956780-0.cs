    class SampleItem
    {
        public string Name { get; set; }
        public string Descr { get; set; }
        public int Group { get; set; }
        public int Value { get; set; }
        public decimal Price { get; set; }
        public DateTime ItemDate { get; set; }
        public bool Active { get; set; }
        public string ConstVal { get; set; }
        public SampleItem()
        {
            ConstVal = "Ziggy";
        }
        public class SampleItemMap : CsvHelper.Configuration.CsvClassMap<SampleItem>
        {
            public SampleItemMap()
            {
                AutoMap();
                Map( m => m.ConstVal).Ignore();
            }
        }
    }
