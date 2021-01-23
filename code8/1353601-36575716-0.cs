     List<MyCustomInterface> trace; 
    
        private class Details: MyCustomInterface
        {
            public string date { get; set; }
            public string type { get; set; }
            public string mex { get; set; }
        }
    
        private class Context:MyCustomInterface
        {
            public List<object> context { get; set; }
        }
