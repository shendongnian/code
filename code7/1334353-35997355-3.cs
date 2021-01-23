    namespace MyNamespace
    {
        public MyController : Controller
        {
            public ActionResult MyActionMethod()
            {
                ViewBag["TimeSlots"] = ListHelper.CreateTimeSlotsList();
                return View();
            }
        }
    }
