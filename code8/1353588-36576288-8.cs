        [RoutePrefix("api/CustomerSpaSilo")]
        public class CustomerSpaSiloController : ApiController
        {
            [HttpPost]
            [Route("SearchCustomers")]
            public IHttpActionResult Post(string nameFilter, [FromBody] PagingViewModel pagingVM)
            {
                if (nameFilter == null)
                    nameFilter = "";
    
                //Code Implementation
    
                return Ok("Result=" + pagingVM.ToString());
            }
        }
