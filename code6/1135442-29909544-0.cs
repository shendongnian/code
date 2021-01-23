                // your data
                var data = new[]{
                new {UserId="User1", ItemId=1},
                new {UserId="User1", ItemId=2},
                new {UserId="User2", ItemId=3},
                new {UserId="User2", ItemId=1}
                };
                var dict = data.AsEnumerable()
                    .GroupBy(x => x.ItemId, y => y.UserId)
                    .ToDictionary(x => x.Key, y => y.ToList());
                foreach (var key in dict.Keys)
                {
                    Console.WriteLine("Item ID : {0}, Values : {1}", key, string.Join(",",dict[key].ToArray()));
                }
                Console.ReadLine();​
