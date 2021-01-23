    public class TypeA
    { }
    public class TypeB
    { }
    public class GenericFilter
    {
        public bool IsOfType<T>(IEnumerable<dynamic> objectToInspect)
        {
            var genericType = objectToInspect.GetType().GenericTypeArguments[0];
            return genericType == typeof(T);
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IdentifiesExpectedType()
        {
            var classToInspect = new List<TypeA>();
            var filter = new GenericFilter();
            Assert.IsTrue(filter.IsOfType<TypeA>(classToInspect));
        }
        [TestMethod]
        public void RejectsNonMatchingType()
        {
            var classToInspect = new List<TypeA>();
            var filter = new GenericFilter();
            Assert.IsFalse(filter.IsOfType<TypeB>(classToInspect));
        }
    }
