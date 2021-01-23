    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var tasks = new List<Task>
            {
                new Task { ID = 1, Name = "One", Status = TaskStatus.ToDo},
                new Task { ID = 2, Name = "Two", Status = TaskStatus.InProgress},
                new Task { ID = 3, Name = "Three", Status = TaskStatus.InTesting},
                new Task { ID = 4, Name = "Four", Status = TaskStatus.Done},
                new Task { ID = 5, Name = "Five", Status = TaskStatus.ToDo},
                new Task { ID = 6, Name = "Six", Status = TaskStatus.InProgress}
            };
                
            var model = tasks.GroupBy(t => t.Status, t => t)
                .Select(g => new TaskGroup {Status = g.Key, Tasks = g as IList<Task>})
                .ToList();
    
            return View(model);
        }
    }
