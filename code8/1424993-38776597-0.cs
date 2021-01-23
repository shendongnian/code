    public class TemplateConstants
    {
        public const string Type = "«Type»";
        public const string Purpose = "«Purpose»";
        public const string FirstName = "«FirstName»";
        private static readonly Lazy<Dictionary<string, string>> ConstantsDictionary =
            new Lazy<Dictionary<string, string>>(CreateDictionary);
        public static Dictionary<string, string> AsDictionary()
        {
            return ConstantsDictionary.Value;
        }
        private static Dictionary<string, string> CreateDictionary()
        {
            var fields = typeof(TemplateConstants)
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            var constants = fields.Where(f => f.IsLiteral && !f.IsInitOnly).ToList();
            var result = new Dictionary<string, string>();
            var instance = new TemplateConstants();
            // Up to you if you want to filter the constants further to only include those
            // with string values.
            constants.ForEach(constant => result.Add(constant.Name, constant.GetValue(instance).ToString()));
            return result;
        }
    }
    [TestClass]
    public class TestTemplateConstants
    {
        [TestMethod]
        public void TestDictionary()
        {
            var dictionary = TemplateConstants.AsDictionary();
            Assert.AreEqual(dictionary["Type"],TemplateConstants.Type);
        }
    }
