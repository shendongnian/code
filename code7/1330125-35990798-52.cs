    public class ValuesController : ApiController
    {
        public class Foo
        {
           public Guid Id { get; set; }
           [JsonConverter(typeof(UtcDateTimeOffsetConverter))]
           public Iso8601SerializableDateTimeOffset AcquireDate { get; set; }
        }
 
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
