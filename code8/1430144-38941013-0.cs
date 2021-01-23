    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    
    namespace WebApplication1.Controllers {
        public class HomeController : Controller {
            public ActionResult Index() {
                object model = CreateScriptObjectFromDataObject(GetModel());
                return View(model);
            }
            private string CreateScriptObjectFromDataObject(IEnumerable dataObject) {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Serialize(dataObject);
            }
            private IEnumerable GetModel() {
                List<DataItem> items = new List<DataItem>();
                
                //LOAD ITEMS FROM DB INSTEAD
    
                items.Add(new DataItem() { rank = 1, rating = 9.2, year = 1994, title = "The Shawshank Redemption" });
                items.Add(new DataItem() { rank = 2, rating = 9.0, year = 1974, title = "The Godfather" });
                items.Add(new DataItem() { rank = 3, rating = 9.2, year = 1994, title = "The Godfather: Part II" });
                items.Add(new DataItem() { rank = 4, rating = 8.9, year = 1966, title = "Il buono, il brutto, il cattivo." });
                items.Add(new DataItem() { rank = 5, rating = 8.9, year = 1994, title = "Pulp Fiction" });
                items.Add(new DataItem() { rank = 6, rating = 8.9, year = 1957, title = "The Shawshank Redemption" });
                items.Add(new DataItem() { rank = 7, rating = 8.9, year = 1993, title = "12 Angry Men" });
                items.Add(new DataItem() { rank = 8, rating = 8.8, year = 1975, title = "One Flew Over the Cuckoo's Nes" });
                items.Add(new DataItem() { rank = 9, rating = 8.8, year = 2010, title = "Inception" });
                items.Add(new DataItem() { rank = 10, rating = 8.8, year = 2008, title = "The Dark Knight" });
    
                return items;
            }
        }
        public class DataItem {
            public int rank { get; set; }
            public double rating { get; set; }
            public int year { get; set; }
            public string title { get; set; }
        }
    }
