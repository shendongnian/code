            var l = new List<pairs>
            {
                new pairs {Index = 0, Value = 1000},
                new pairs {Index = 1, Value = 1000},
                new pairs {Index = 2, Value = 1000},
            };
            var gr = l.GroupBy(a => a.Value);
            var count = gr.Count(); // <- count is 1
