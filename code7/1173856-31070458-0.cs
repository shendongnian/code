        class MyClass
        {
            public MyClass()
            {
                this.content = new ConcurrentDictionary<string, string>();
            }
            ConcurrentDictionary<string, string> content;
            public IDictionary<string, string> MyContent { get { return content; } }
            public void AddOrUpdateDictionary(string key, string value)
            {
                content.AddOrUpdate(key, value, (k, contentValue) => string.Concat(contentValue, value));   
            }
        }
