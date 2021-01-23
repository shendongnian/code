            var transportId = 5;
            var res = from Store s in _context.Stores                      
                      group s by s.Type1 into pt1                      
                      select new TypeTransportation()
                            {
                                Type = int.Parse(pt1.Key), // Needs to be int
                                Count = _context.Products.Where(i=>i.Type== int.Parse(pt1.Key) 
                                    && i.transportId==transportId).Count()
                            };
            foreach (var item in res)
            {
                Console.WriteLine(item.Type + " " +item.Count );
            }
            Console.ReadKey();
