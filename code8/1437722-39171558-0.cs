        [Fact]
        public void BindList()
        {
            var input = new Dictionary<string, string>
            {
                {"StringList:0", "val0"},
                {"StringList:1", "val1"},
                {"StringList:2", "val2"},
                {"StringList:x", "valx"}
            };
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(input);
            var config = configurationBuilder.Build();
            var list = new List<string>();
            config.GetSection("StringList").Bind(list);
            Assert.Equal(4, list.Count);
            Assert.Equal("val0", list[0]);
            Assert.Equal("val1", list[1]);
            Assert.Equal("val2", list[2]);
            Assert.Equal("valx", list[3]);
        }
