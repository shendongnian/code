    public class saveDataController : ApiController
        {
            [HttpPost]
            public static void writeData(input input)
            {
                var jsonString = new JavaScriptSerializer().Serialize(input);
                //other code
            }
     
        }
