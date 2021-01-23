    namespace TodoApi.Controllers
    {
    [RoutePrefix("api/[controller]")]
    public class TodoController : Controller
    {
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }
    	Route("First")]
        public IEnumerable<TodoItem> GetAll1()
        {
            return TodoItems.GetAll();
        }
    	
    	[Route("Second")]
        public IEnumerable<TodoItem> GetAll2()
        {
            return TodoItems.GetAll();
        }
    
        [HttpGet("{id}", Name="GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
                return HttpNotFound();
            return new ObjectResult(item);
        }
    
        public  ITodoRepository TodoItems { get; set; }
    
    }
