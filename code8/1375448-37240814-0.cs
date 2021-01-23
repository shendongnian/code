    //your class
        public class Item
        {
            int ID;
            public string Name;
            public double Price;
        }
    //code:
        List<Item> = conn.Query("SELECT * FROM tableX").ToList();
        var result = Json(Item, JsonRequestBehavior.AllowGet);
