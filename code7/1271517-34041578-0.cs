    static int cal()
        {
            string[] store = input.Split(' ');
            var res = 0;
            int value;
            
            var mapOp = new Dictionary<string, Func<List<int>, int>>();
            mapOp.Add("+", l => l.Aggregate(0, (x, y) => x + y));
            mapOp.Add("-", l => l.Skip(1).Aggregate(l[0], (x, y) => x - y));
            var process = new Action<string,List<int>>((o, l) =>
            {
                var operation = mapOp[o];
                var result = operation(l);
                l.Clear();
                l.Add(result);
            });
            var numbers = new List<int>();
            foreach (var i in store)
            {
                if (int.TryParse(i, out value))
                    numbers.Add(value);
                else
                    process(i, numbers);
            }
            return numbers.First();
        }
