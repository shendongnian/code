        //Only request with Post Verb that can contain body
        [AcceptVerbs("POST")]
        public HttpResponseMessage addBusOrder([FromBody]BusOrderModel)
        {
            //done some work here
        }
        
        //You may want to separate model into a class library so that server and client app can share the same model
            public class BusOrderModel
            {
                public string UserUniqueID { get; set; }
                public int PlatFormID { get; set; }
                public string DeviceID { get; set; }
                public int RouteScheduleId { get; set; }
                public string JourneyDate { get; set; }
                public int FromCityid { get; set; }
                public int ToCityid { get; set; }
                public int TyPickUpID { get; set; }
                public Contactinfo ContactInfo { get; set; }
                public passenger[] pass { get; set; }
            }
