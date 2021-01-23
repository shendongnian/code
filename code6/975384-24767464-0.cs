    public class MileageServiceController : ApiController
    {
        // GET: api/MileageService?locations=100NewYork&locations=300NewJersey
        public string Get([FromUri] String[] locations)
        {
            String value = String.Empty;
            //TO DO - GOT TO DLL and get milage
            foreach (String loca in locations)
            {
                //you could go to your DLL here 
                //value += DLL.GetMilage(loca.ID, loca.City, etc...
                value += loca; //for testing
            }
            return value;
        }
    }
