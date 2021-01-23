            using (var cursor = collection.FindAsync(filter))
            {
                Console.WriteLine("1");
                while (cursor.Result.MoveNext())
                {
                    var batch = cursor.Result.Current;
                    foreach (Follower foll in batch)
                        fetchedFollowers.Add(foll);
                }
            }
