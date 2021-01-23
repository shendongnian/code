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
                string item3 = "Network Type";
                var GenreLst = new List<string> { "Manufacturer", "Model", "NetworkType", };
                List<Mobiles> Mobs = new List<Mobiles>(){
                    new Mobiles() { ID = 1, Manufacturer = "Samsung", Model = "S4", NetworkType = "Orange" },
                    new Mobiles(){  ID = 2, Manufacturer = "Nokia", Model ="X1", NetworkType ="O2"},
                    new Mobiles(){ ID = 3, Manufacturer = "Sony", Model = "Z1", NetworkType = "Orange"}
                };
    
    
                var filterresults = from m in Mobs
                                    select m;
                ViewBag.searchGenre = new SelectList(GenreLst);
    
                if (GenreLst.Contains(Convert.ToString(item1)))
                {
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        filterresults = filterresults.Where(k => k.Manufacturer.Contains(searchString));
                    }
                }
                else if (GenreLst.Contains(Convert.ToString(item2)))
                {
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        filterresults = filterresults.Where(x => x.Model.Contains(searchString));
                    }
                }
                else if (GenreLst.Contains(Convert.ToString(item3)))
                {
                    if (!string.IsNullOrEmpty(searchString))
                    {
                        filterresults = filterresults.Where(v => v.NetworkType.Contains(searchString));
                    }
                }
                return View("Index", filterresults);
            }
    }
