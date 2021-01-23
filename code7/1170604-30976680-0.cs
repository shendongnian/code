    public class MyLovelyClass
    {
        public Int32 Number { get; set; }
        public bool Selection { get; set; }
    }
    var packs = from r in new XPQuery<Roll>(session)
                select new MyLovelyClass()
                {
                   Number = r.number                
                };
    gcPack.DataSource = packs;
