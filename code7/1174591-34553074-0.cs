    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TestWriterAttribute : PropertyAttribute
    {
        public TestWriterAttribute() : base()
        {
            // Create a container for test output
            Properties["Output"] = new StringBuilder();
        }
    }
