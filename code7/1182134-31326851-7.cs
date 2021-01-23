    public static void GetWhereIn()
        {
            var collection = new List<INVENTTXT>()
            {
                new INVENTTXT {ITEMID = "52719635"}
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
