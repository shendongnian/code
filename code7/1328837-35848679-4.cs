        class StringLogger : List<string>, ILogger
        {
            public void ErrorLogging(string input)
            {
               Add(input);
            }
        }
        var testSubject = new MyClassthatDoesStuff(new StringLogger());
