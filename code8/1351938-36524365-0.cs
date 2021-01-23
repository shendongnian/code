    [Route("api/Subscribers/{id}/[controller]", Name = "SubscriberLink")]
    [Route("api/Organizations/{id}/[controller]", Name = "OrganizationLink")]
    public class AddressesController : Controller
    {
    
        [HttpGet("{aid}")]
        public async Task<IActionResult> GetAddress(Guid id, Guid aid)
        {
            //...implementation is irrelevant for this question.
        }
    }
