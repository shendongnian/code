            var entity1 = new Entity
            {
                OrderNumber = "1",
                TrackingNumber = "100"
            };
            var entity2 = new Entity
            {
                OrderNumber = "2",
                TrackingNumber = "101"
            };
            var entity3 = new Entity
            {
                OrderNumber = "1",
                TrackingNumber = "100"
            };
            var list = new EntityList();
            list.Add(entity1);
            list.Add(entity1);
            list.Add(entity3);
            Console.WriteLine("Count : " + list.Count);
