    public class YourController : Controller
    { 
        private IMyTable myTable;
        public YourController(IMyTable myTable)
        {
            this.myTable = myTable;
        }
        public ActionResult YourAction()
        {
            var result = myTable.findAll();
            // ...
        }
    }
 
