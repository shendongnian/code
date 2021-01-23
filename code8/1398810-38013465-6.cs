    namespace Pat.PostingService.Api.Version1
    {
        [RoutePrefix("SpecialDeliveryServiceStatus")]
        public class DeliveryStatusController : ApiController
        {
             //GET SpecialDeliveryServiceStatus/{deliveryType}/{orderId}
             [HttpGet]
             [Route("{deliveryType}/{orderId?}")]
             [ResponseType(typeof(DeliveryStatusDto))]
             public dynamic Get(string deliveryType, Guid? orderId = null) { ... }
        }
    }
