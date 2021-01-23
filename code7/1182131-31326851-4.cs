    public static void GetWhereIn()
        {
            var collection = new List<INVENTTXT>()
            {
                new INVENTTXT {ITEMID = "1"},
                new INVENTTXT {ITEMID = "2"},
                new INVENTTXT {ITEMID = "3"},
                new INVENTTXT {ITEMID = "4"},
                new INVENTTXT {ITEMID = "5"},
                new INVENTTXT {ITEMID = "6"},
                new INVENTTXT {ITEMID = "7"},
                new INVENTTXT {ITEMID = "8"}
            };
            var temp = new BsonValue[collection.Count()];
            for (int i = 0; i < collection.Count(); i++)
            {
                temp[i] = collection[i].ITEMID;
            }
            
            var query = Query.In("ITEMID", collection.Select(c => BsonValue.Create(c.ITEMID)));
            var collection2 = db.GetCollection<INVENTTXT>("INVENTTXT").Find(query).ToList();
            var count = collection2.Count;
        }
