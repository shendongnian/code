    sealed class TestAssemblyResolver : IAssemblyResolver {
        public string GetEntryAssemblyPath() {
            // Return path of a well-known test application,
            // for example an "empty" console application. You can also
            // reuse it to, for example, return different error codes
            return Assembly.Load(...);
        }
    }
