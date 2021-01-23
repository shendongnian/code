    public static Tortuga.Chain.AccessDataSource DataSource = Tortuga.Chain.AccessDataSource.CreateFromConfig("VendorConnection");
    public class Foo
    {
        public int? VNNO { get; set; }
        public string VnnoString
        {
            get
            {
                if (VNNO.HasValue)
                    return VNNO.ToString();
                else
                    return "";
            }
        }
        public string VNNAME { get; set; }
    }
    var items = dataSource.From("MY PPUR301").WithSorting("VNNO").ToCollection<Foo>().Execute();
    foreach (var item in items)
    {
        vendors.Add(new SelectListItem { Text = item.VNNAME.ToUpper(), Value = item.VnnoString });
    }
