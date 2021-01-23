    class MockEnvironment
    {
        private Dictionary<string, string> _mockEnvironment;
        public string GetVariable(string variableName)
        {
            return _mockEnvironment[variableName];
        }
        public void SetVariable(string variableName, string value)
        {
            // Check for entry not existing and add to dictionary
            _mockEnviroment[variableName] = value;
        }
    }
