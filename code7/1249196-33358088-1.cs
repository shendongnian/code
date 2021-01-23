    public class TestClass
    {
        public string Name { get; set; }
        public int Integer { get; set; }
        public int? NullInteger { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? NullableDateTime { get; set; }
        public static void Test()
        {
            try
            {
                TestInner();
            }
            catch (Exception ex)
            {
                Debug.Assert(false, ex.ToString());
                throw;
            }
        }
        public static void TestInner()
        {
            var test = new TestClass();
            var settings = new DataWriterSettings(new SkipNullResolverStrategy());
            var writer = new JsonWriter(settings);
            var json = writer.Write(test);
            Debug.WriteLine(json); // Outputs {"Integer":0,"DateTime":"0001-01-01T00:00:00"}
            if (json.Contains("null"))
            {
                throw new InvalidOperationException("json.Contains(\"null\")"); // No exception
            }
        }
    }
