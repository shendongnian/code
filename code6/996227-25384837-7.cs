    public class Mobiles
        {
            public int ID { get; set; }
    
            public string Manufacturer { get; set; }
    
            public string Model { get; set; }
    
            public string NetworkType { get; set; }
        }
    
        public class HomeController : Controller
        {
          public ActionResult Index(string searchGenre, string searchString)
        {
            string item1 = "Manufacturer";
            string item2 = "Model";
            string item3 = "NetworkType";
            var GenreLst = new List<string> { item1, item2, item3, };
            List<Mobiles> Mobs = new List<Mobiles>(){
                new Mobiles() { ID = 1, Manufacturer = "Samsung", Model = "S4", NetworkType = "Orange" },
                new Mobiles(){  ID = 2, Manufacturer = "Nokia", Model ="X1", NetworkType ="O2"},
                new Mobiles(){ ID = 3, Manufacturer = "Sony", Model = "Z1", NetworkType = "Orange"}
            };
            var filterresults = from m in Mobs
                                select m;
            ViewBag.searchGenre = new SelectList(GenreLst);
            // ToLower for case
            if (!String.IsNullOrEmpty(searchGenre))
            {
                switch (searchGenre)
                {
                    case "Manufacturer":
                        filterresults = filterresults.Where(k => k.Manufacturer.Contains(searchString));
                        break;
                    case "Model":
                        filterresults = filterresults.Where(x => x.Model.Contains(searchString));
                        break;
                    case "NetworkType":
                        filterresults = filterresults.Where(v => v.NetworkType.Contains(searchString));
                        break;
                    default:
                        // Something defaulty if you want.
                        break;
                }
            }
            return View("Index", filterresults);
        }
    }
