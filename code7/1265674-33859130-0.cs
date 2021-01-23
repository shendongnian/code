        public void TestMethod1()
        {
            AutoMapper.Mapper.Initialize(Configure);
            var alpha = new Alpha();
            var bravo = AutoMapper.Mapper.Map<Bravo>(alpha);
            Assert.IsNull(alpha.Collection);
            Assert.IsNull(bravo.Collection);
        }
        public static void Configure(AutoMapper.IConfiguration config)
        {
            config.AllowNullCollections = true;
            config.AllowNullDestinationValues = true;
            config.CreateMap<Alpha, Bravo>();
        }
        public class Alpha
        {
            public List<int> Collection { get; set; }
        }
        public class Bravo
        {
            public List<int> Collection { get; set; }
        }
    }
