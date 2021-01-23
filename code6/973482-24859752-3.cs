    namespace MvcApplication1.Controllers
    {
        public class ValuesController : ApiController
        {
            ......
    
            [GET("api/libraries", Precedence = 2)]
            public string Get_1(string id)
            {
                return "value :" + id;
            }
    
            [GET("api/libraries/bookStatus/{id:long}", Precedence = 1)]
            public string Get_2(int id)
            {
                return "value :" + id;
            }
            
            ......
        }
    }
