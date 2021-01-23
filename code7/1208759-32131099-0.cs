    namespace WebApplication4.Controllers
    {
        public class GreetingController : ApiController
        {
               public string GetGreeting() {
                return "Hello World!";
                }
    
        public static List<Greeting> _greetings = new List<Greeting>();
        public HttpResponseMessage PostGreeting(Greeting greeting)
        {
            _greetings.Add(greeting);
            var greetingLocation = new Uri(this.Request.RequestUri, "greeting/" + greeting.Name);
            var response = this.Request.CreateResponse(HttpStatusCodeResult.Created);
            response.Headers.Location = greetingLocation;
            return response;
    
        }
    }  
    }
