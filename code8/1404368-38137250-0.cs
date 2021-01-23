    //Inside API controller class library
    [RoutePrefix("Persons")]
    public class PersonController : ApiController
    {
        [Route("")]
        public List<Person> GetAll()
        {
            List<Person> results = new List<Person>();
            try
            {
                //TODO: Call Data Access Layer
                //FORNOW: Mock up some data
                results.Add(new Person() { Name = "Ryan C" });
                results.Add(new Person() { Name = "Siavash R" });
            }
            catch
            {
                //TODO: Handle error
            }
            return results;
        }
    }
