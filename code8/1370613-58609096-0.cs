    public class CustomException : Exception
    {
        public CustomException()
        {
            var stackTraceField = typeof(CustomException).BaseType
                .GetField("_stackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);
            stackTraceField.SetValue(this, Environment.StackTrace);
        }
    }
