            var values = new int[] {1, 2, 3, 4, 5};
            List<dynamic> list = new List<dynamic>();
            foreach (var value in values)
            {
                var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
                dynamicObject[value.ToString()] = value;
                list.Add(dynamicObject);
            }
            // Kind of ugly as cast but otherwise it has trouble to find the Count property
            var result = list.Sum(x => (x as IDictionary<string, Object>).Count);
            Console.WriteLine("Result: {0}", result);
            Console.ReadLine();
