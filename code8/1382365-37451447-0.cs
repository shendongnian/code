            List<Tuple<string, int>> Fruits = new List<Tuple<string, int>>();
            Fruits.Add(Tuple.Create("Apple", 10));
            Fruits.Add(Tuple.Create("Apple", 5));
            Fruits.Add(Tuple.Create("Apple", 20));
            Fruits.Add(Tuple.Create("Mango", 10));
            Fruits.Add(Tuple.Create("Orange", 10));
            Fruits.Add(Tuple.Create("Mango", 20));
            Fruits.Add(Tuple.Create("Orange", 12));
            foreach (var item in Fruits.GroupBy(s => s.Item1))
            {
                string FruitName = item.Key;
                StringBuilder sb = new StringBuilder();
                foreach (var price in item)
                    sb.Append(price.Item2 + ", ");
                Console.WriteLine(string.Format("Fruit Name :{0} Prices :{1}", FruitName, sb.ToString().Trim(new char[] { ',', ' ' })));
            }
       output:
     Fruit Name :Apple Prices :10, 5, 20
     Fruit Name :Mango Prices :10, 20
     Fruit Name :Orange Prices :10, 12
