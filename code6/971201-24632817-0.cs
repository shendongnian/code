            var bag = new HashBag<int>
                      {
                          1,
                          2,
                          3
                      };
            var g = new GuardedCollection<int>(bag);
            bag.Add(4);
            g.Add(5);
