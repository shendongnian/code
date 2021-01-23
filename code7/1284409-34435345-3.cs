        static void Main(string[] args)
        {
            var l1 = new List<Foo> { };
            for(var i = 0; i < 10000000; i++)
            {
                l1.Add(new Foo { Name = "x" + i.ToString() });
            }
          
            var propertyName = nameof(Foo.Name);
            var lambda = MakeLambda<Foo>(propertyName);
            var f = lambda.Compile();
            var propertyInfo = typeof(Foo).GetProperty(nameof(Foo.Name));
            var sw1 = Stopwatch.StartNew();
            foreach (var item in l1)
            {
                var value = f(item);
            }
            sw1.Stop();
            var sw2 = Stopwatch.StartNew();
            foreach (var item in l1)
            {
                var value = propertyInfo.GetValue(item);
            }
            sw2.Stop();
            Console.WriteLine($"{sw1.ElapsedMilliseconds} vs {sw2.ElapsedMilliseconds}");
            
          
        }
