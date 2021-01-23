    class Product
    {
        public Product(string currentName, string refCode, int year)
        {
            CurrentName = currentName;
            RefCode = refCode;
            Year = year;
        }
        public string CurrentName { get; }
        public string RefCode { get; }
        public int Year { get;}
    }
    class ProductEqualityComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product x, Product y)
        {
            return x.RefCode.Equals(y.RefCode);
        }
        public override int GetHashCode(Product obj)
        {
            return obj.RefCode.GetHashCode();
        }
    }
    
    [TestClass]
    public class CompareEntriesFixture 
    {
        [TestMethod]
        public void CompareEntries()
        {
            var list1 = new List<Product>
            {
                new Product("GenP", "MMO1", 2015),
                new Product("GenS", "MMO2", 2015),
                new Product("GenK", "MMO3", 2014),
            };
            var list2 = new List<Product>
            {
                new Product("GenP2", "MMO1", 2016),
                new Product("GenS3", "MMO2", 2016),
                new Product("GenKF", "MM15", 2016),
            };
            var expected = new List<Product>
            {
                new Product("GenP", "MMO1", 2015),
                new Product("GenS", "MMO2", 2015)
            };
            var common = list1.Intersect(list2, new ProductEqualityComparer()).ToList();
            CollectionAssert.AreEqual(expected, common, new ProductComparer());
        }
    }
