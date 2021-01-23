      public class DisplayTableController : Controller
      {
        private List<Group> groups = new List<Group>
            {
              new Group { GroupID = 1, Name = "Group 1" },
              new Group { GroupID = 2, Name = "Group 2" }
            };
    
        public ActionResult Index()
        {
          return View(groups);
        }
    
        [HttpPost]
        public ActionResult Index(List<Group> viewModel)
        {
          return View(viewModel);
        }
    
        [HttpPost]
        public ActionResult Search(Group group)
        {
          var result = groups.Where(g => g.GroupID == group.GroupID).ToList();
          return View("Index", result);
        }
      }
