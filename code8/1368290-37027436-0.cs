    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var numberList = new List<int>();
            numberList.AddRange(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var totalNumber = 0;
            var count = 0;
            foreach (var item in numberList)
            {
                totalNumber += item;
                if (item == 5)
                {
                    numberList.Remove(count);
                }
                count = count + 1;
            }
            return View(totalNumber);
        }
    }
