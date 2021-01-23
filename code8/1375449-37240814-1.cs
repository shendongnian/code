    //your class
        public class Item
        {
            int ID;
            public string Name;
            public double Price;
        }
    //code:
        List<Item> = conn.Query<Item>("SELECT * FROM tableX").AsList();
        var result = Json(Item, JsonRequestBehavior.AllowGet);
