	[TestClass]
    public class CsvHelperTest
    {
        [TestMethod]
        public void Test()
        {
            var textToParse = "SupplierSku,CatIds,StockStatus,Active" + Environment.NewLine;
            textToParse += "%ADA-BB-124%|4,5,1|%AV%|1" + Environment.NewLine;
            textToParse += "%XAS-E4-S11%|97,41,65|%OS%|0";
    
            using (var stringReader = new StringReader(textToParse))
            {
                using (var reader = new CsvReader(stringReader))
                {
                    reader.Configuration.Quote = '%';
                    reader.Configuration.Delimiter = "|";
                    reader.Configuration.HasHeaderRecord = true; // If there is no header, set to false.
                    reader.Configuration.RegisterClassMap<StockMap>();
    
                    foreach(var stock in reader.GetRecords<Stock>())
                    {
                        // normally do something with data, now just test
    
                        Assert.IsNotNull(stock.SupplierSku);
                        Assert.IsTrue(stock.SupplierSku.IndexOf('%') == -1, "Quotes should be stripped");
                        Assert.IsNotNull(stock.CatIds);
                        Assert.AreEqual(3, stock.CatIds.Length, "Expected 3 CatIds");
                    }
                }
            }
        }
    
        public class StockMap : CsvClassMap<Stock>
        {
            public StockMap()
            {
                Map(stock => stock.SupplierSku).Index(0);
                Map(stock => stock.CatIds).Index(1).TypeConverter<CatIdsConverter>();
                Map(stock => stock.StockStatus).Index(2);
                Map(stock => stock.Active).Index(3); // 1 is true, 0 is false
            }
        }
    
        public class Stock
        {
            public string SupplierSku { get; set; }
            public int[] CatIds { get; set; }
            public StockStatus StockStatus { get; set; }
            public bool Active { get; set; }
        }
    
        public enum StockStatus
        {
            AV, OS
        }
    
        public class CatIdsConverter : DefaultTypeConverter
        {
            public override bool CanConvertFrom(Type type)
            {
                return type == typeof(string);
            }
    
            public override object ConvertFromString(TypeConverterOptions options, string text)
            {
                if (string.IsNullOrEmpty(text))
                    return null;
    
                var catIds = text.Split(',').Select(c=> Convert.ToInt32(c)).ToArray();
                return catIds;
            }
        }
    }
