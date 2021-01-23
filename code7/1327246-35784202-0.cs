    public static Dictionary<int, string> Datas
        {
            get
            {
                return Enumerable.Range(0, 100) //Lots of numbers
                                 .ToDictionary(x => x, x => Guid.NewGuid().ToString());
            }
        }
     
        [Test]
        public void MultiCacheTest([ValueSource("Datas")] KeyValuePair<int, string> item)
        {                       
    		//ACT ...Yes this tests Guid.Parse 100 times
            var value = Guid.Parse(item.value);
    
            Assert.AreEqual(item.Value, value.ToString());           
        }
