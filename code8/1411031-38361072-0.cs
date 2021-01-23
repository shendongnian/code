    public class CustomerApiController : ApiController
    {
    [LocalizationWebApi]
    [HttpGet]
    [SessionControlWebApi]
    [ScreenAccess(SCREEN_ACCESS.Show)]
    public JsonResult<CustomerOrderFormSearchResult> CustomerOrderFormSearch(CustomerOrderFormSearchModel Model_)
    {
           CustomerOrderFormSearchResult ret_ = new CustomerOrderFormSearchResult();
           ret_.Errors.Add(ResourceExtensions.Language("SHARED_MESSAGE_SESSIONCLOSED"));
           return OK(ret_);
           //Better to return Ok in your search result
          // If you want validation use NotFound() or something slimier to that 
     }
    }
