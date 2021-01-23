    [TestFixture]
    public class LinqToObjectTests
    {
        [Test]
        public void ThereShouldBeOnlyOneListForUK()
        {
            var list = new List<List<object>>
            {
                new List<object>(), 
                new List<object>()
            };
    
            list[0].Add("Name");
            list[0].Add("UK");
            list[0].Add("Title");
    
    
            list[1].Add("Name");
            list[1].Add("NOT UK");
            list[1].Add("Title");
            var query = from item in list where item[1] == "UK" select item;
            Assert.AreEqual(1, query.Count());
        }
    }
