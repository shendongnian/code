    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Foo> Get()
        {
            return new Foo[] {
                new Foo() {
                    Id = Guid.NewGuid(),
                    AcquireDate = DateTimeOffset.Now
                }
            };
        }
     }
