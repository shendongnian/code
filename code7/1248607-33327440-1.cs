    [RoutePrefix("api")]
    public class DefaultController : ApiController
    {
        [HttpPost]
        // I prefer using attribute routing
        [Route("addBusOrder")]
        // FromUri means that the parameter comes from the uri of the request
        // FromBody means that the parameter comes from body of the request
        public IHttpActionResult addBusOrder([FromUri]string userUniqueId,
                                                [FromUri]int platFormId,
                                                [FromUri]string deviceId, [FromUri]int routeScheduleId,
                                                [FromUri]string journeyDate, [FromUri]int fromCityid,
                                                [FromUri]int toCityid, [FromUri]int tyPickUpId,
                                                [FromBody]PassengersContact passengersContact)
        {
            // Just for testing: I'm returning what was passed as a parameter
            return Ok(new
            {
                UserUniqueID = userUniqueId,
                PlatFormID = platFormId,
                RouteScheduleId = routeScheduleId,
                JourneyDate = journeyDate,
                FromCityid = fromCityid,
                ToCityid = toCityid,
                TyPickUpID = tyPickUpId,
                PassengersContact = passengersContact
            });
        }
    }
