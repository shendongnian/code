    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [FromServices]
        public IAccountRepository Repository { get; set; }
        [HttpGet]
        public IEnumerable<UserAccount> Get() {
            return Repository.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var account = Repository.GetUserAccount(id);
            if (account == null)
                return HttpNotFound();
            return new ObjectResult(account);
        }
        [HttpPost]
        public IActionResult Post([FromBody] UserAccount item) {
            if (item == null)
                return HttpBadRequest();
            var account = Repository.Add(item);
            return new ObjectResult(account);
        }
        [HttpDelete("{id}")]
        public void Delete(int id) {
            Repository.Remove(id);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserAccount item) {
            if (item == null)
                return HttpBadRequest();
            if (!Repository.Update(item))
                return HttpNotFound();
            return new ObjectResult(item);
        }
    }
