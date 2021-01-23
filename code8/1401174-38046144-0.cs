    public class PagingController : Controller
    {
        public ActionResult Index(int?page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            List<Item> items = this.GetItems();
            return View(items.ToPagedList(pageNumber, pageSize));
        }
        private List<Item> GetItems()
        {
            var item1 = new Item { Description = "Item 1", Number = "1" };
            var item2 = new Item { Description = "Item 2", Number = "2" };
            var item3 = new Item { Description = "Item 3", Number = "3" };
            var item4 = new Item { Description = "Item 4", Number = "4" };
            var item5 = new Item { Description = "Item 5", Number = "5" };
            var item6 = new Item { Description = "Item 6", Number = "6" };
            var item7 = new Item { Description = "Item 7", Number = "7" };
            var item8 = new Item { Description = "Item 8", Number = "8" };
            return new List<Item> { item1, item2, item3, item4, item5, item6 ,item7, item8};
        }
    }
