    [TestFixture]
    public class SomeObjectTests {
        private static readonly SomeObject item0 = new SomeObject(0.0);
        private static SomeObject getObject(string key)
        {
            if ( key == "item0" )
                return item0;
            throw new ArgumentException("Unknown key");
        }
        [TestCase("item0", ExpectedResult = 0.0)]
        public double TestSomeObjectValue(string key) {
            SomeObject so = getObject(key);
            return so.Value;
        }
        [TestCase("item0", ExpectedResult = "0.0")]
        public string TestSomeObjectValueString(string key) {
            SomeObject so = getObject(key);
            return so.ValueString;
        }
    }
