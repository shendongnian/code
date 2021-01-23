    List<List<List<string>>> list1 = new List<List<List<string>>>
                {
                    new List<List<string>> {
                    new List<string>{"a","b","c","d","e"},
                    new List<string>{"a","b","c","d","e"},
                    new List<string>{"a","b","c","d","e"}
                    },
                    new List<List<string>> {
                    new List<string>{"a","b","c","d","e"},
                    new List<string>{"a","b","c","d","e"},
                    new List<string>{"a","b","c","d","e"}
                    },
                    new List<List<string>> {
                    new List<string>{"a","b","c","d","e"},
                    new List<string>{"a","b","c","d","e"},
                    new List<string>{"a","b","c","d","e"}
                    }
                };
    
                var result = list1.SelectMany(a => a.SelectMany(b => b.Select(c => c))).ToList();
