    public class LeadsController : ApiController
    {
        [Logger]
        public List<string> Get()
        {
            return new List<string> { "Lead 1", "Lead 2", "Lead 3", "Lead 4","Lead 5" };
        }
    }
