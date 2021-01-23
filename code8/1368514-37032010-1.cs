    public class TourController : ApiController
        {
            public string RequestTours([FromBody] DateRequest request)
            {
                return request.Date;
            }
        }
    
        public class DateRequest
        {
            public string Date { get; set; }
        }
