    [Route("api/[controller]")]
    public class MyController : Controller
    {
        private readonly personHelper helper;
        public MyController(PersonHelper helper)
        {
            this.helper = helper;
        }
        // POST api/my
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var person = new tbl_Person
            {
              // ...
            }
            return helper.InsertPerson(person);
        }
    }
