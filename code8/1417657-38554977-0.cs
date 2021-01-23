    class MyEnvironment
    {
        public string GetVariable(string variableName)
        {
            return Environment.GetEnvironmentVariable(variableName);
        }
        public void SetVariable(string variableName, string value)
        {
            Environment.SetEnvironmentVariable(variableName, value);
        }
    }
