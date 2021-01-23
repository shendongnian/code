I'm going to answer the question directly cause its a learning experience. Although, I would probably split it into two separate lists as suggested by other people. The general rule of thumb is one view (.cshtml thing) per one model, although at work we built a ViewEngine to render List'TBase' so lol. 
    namespace SOAnswer0729.Controllers
    {
    public class HomeController : Controller
    {
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("Tasks");
        }
        public ActionResult Tasks()
        {
            var tasks = new Tasks();
            var model = tasks.getAllTasks();
            return View(model);
        }
    }
    public class Tasks
    {
        public List<BaseTask> taskslist { get; set; }
        public Tasks()
        {
            taskslist = getAllTasks();
        }
        public List<BaseTask> getAllTasks()
        {
            //get data
            List<BaseTask> tempTasks = new List<BaseTask>();
           
            tempTasks.AddRange(DataRepository.WorkSeedData);            
            tempTasks.AddRange(DataRepository.HomeSeedData);
            
            return tempTasks;
        }
        public enum TaskType
        {
            Undefined = 0,
            WorkTask = 1,
            HomeTask = 2
        }
    }
    public static class DataRepository
    {
        public static List<WorkTask> WorkSeedData = new List<WorkTask>() { 
            new WorkTask() { id = 1, Company = "MSFT", Description = "Write Code" },
            new WorkTask() { id = 2, Company = "ATT", Description = "Sell Service" },
            new WorkTask() { id = 3, Company = "XFTY", Description = "Retain Customers" }
        };
        public static List<HomeTask> HomeSeedData = new List<HomeTask>() {
            new HomeTask() { id = 11, UserName = "Jim", Description = "Make Keys" },
            new HomeTask() { id = 12, UserName = "Bob", Description = "Find Keys" },
            new HomeTask() { id = 13, UserName = "Alice", Description = "Intecept Keys" }
        };
    }
    public class BaseTask
    {
        public int id { get; set; }
        public String Description { get; set; }
    }
    public class WorkTask : BaseTask
    {
        public String Company { get; set; }
    }
    public class HomeTask : BaseTask
    {
        public String UserName { get; set; }
    }
