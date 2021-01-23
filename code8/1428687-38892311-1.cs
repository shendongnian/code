    [Route("api/[controller]")]
    public class EntityController : Controller
    {
    
       [HttpGet("{number}")]
       public Entity Get(int number)
       {
           return yourList.Where(en => en.Number == number).FirstOrDefault();
       }
    }
