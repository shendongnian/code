             var items = new Dictionary<int, string>();
             items.Add(1, "SomeData");
             items.Add(5, "SomeData");
             items.Add(23, "SomeData");
             items.Add(22, "SomeData");
             items.Add(2, "SomeData");
             items.Add(7, "SomeData");
             items.Add(59, "SomeData"); 
             var sortedArray = items.Keys.OrderBy(x => x).ToArray();
             int minDistance = int.MaxValue;
             for (int i = 1; i < sortedArray.Length; i++)
             {
                 var distance = Math.Abs(sortedArray[i] - sortedArray[i - 1]);
                 if (distance < minDistance)
                     minDistance = distance;
             }
             Console.WriteLine(minDistance);
