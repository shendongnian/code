    [TestFixture]
    public class Class1
    {
  
        private OrderedDictionary MergeDictionaries(params OrderedDictionary[] dictionaries)
        {
            var merged = new OrderedDictionary();
            foreach (var dictionary in dictionaries)
            {
                foreach (DictionaryEntry entry in dictionary)
                {
                    merged.Add(entry.Key, entry.Value);
                }
            }
            return merged;
        }
        [Test]
        public void Test()
        {
            var d1 = new OrderedDictionary
            {
                {"x", "v1"},
                {"b", "v2"},
            };
            var d2 = new OrderedDictionary
            {
                {"d", "v3" },
                {"c", "v4" }
            };
            var d3 = new OrderedDictionary
            {
                {"z", "v5" },
                {"y", "v6" }
            };
    
            var merged = MergeDictionaries(d1, d2, d3);
    
            var expected = new OrderedDictionary
            {
                {"b", "v2"},
                {"c", "v4" },
                {"d", "v3" },
                {"x", "v1"},
                {"y", "v6" },
                {"z", "v5" }
            };
    
            Assert.That(merged, Is.EquivalentTo(expected));
        }
    }
