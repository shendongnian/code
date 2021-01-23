    [RoutePrefix("{member_id:int}/hotels")]
    public class HotelsController : ApplicationController
    {
        [Route("delete/{id:int}", Name = NamedRoutes.HotelDelete)]
        public ActionResult Delete(int id)
        {
        }
        [Route("new", Name = NamedRoutes.HotelNew)]
        public ActionResult New()
        {
        }
        [HttpPost]
        [ValidateInput(false)]
        [Route("new", Name = NamedRoutes.HotelNewPost)]
        public ActionResult New(HotelDataEntry hotel)
        {
        }
        [Route("edit/{id:int}", Name = NamedRoutes.HotelEdit)]
        public ActionResult Edit(int id)
        {
        }
        [HttpPost]
        [ValidateInput(false)]
        [Route("edit/{id:int}", Name = NamedRoutes.HotelEditPost)]
        public ActionResult Edit(HotelDataEntry hotel)
        {
        }
    }
