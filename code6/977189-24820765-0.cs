     public class CustomViewModel
        {
            public string Item { get; set; }
            public string Title { get; set; }
            public Categories Categories { get; set; }
        }
        public class Categories
        {
            public int Id { get; set; }
            public string CategoryName { get; set; }
        }
        public ActionResult Details(Item item)
        {
            var db = new appContext();
            var model = new CustomViewModel{
                Item = item.ItemTitle,
                ItemLink = "http://localhost:4444/Items/Details/" + item.ItemId,
                Categories = (item.Categories.Select(c => 
                    new Categories{ Id = c.Id,CategoryName= c.CategoryName})).ToList()
            };
            return View(model);
        }
