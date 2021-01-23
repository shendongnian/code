    public class ExampleController : ApiController
    {
        [Route("test")]
        public async Task<IHttpActionResult> GetDk([ModelBinder(typeof(DkDateTimeModelBinder))]DkDateTime sendDate) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            return Ok(sendDate);
        }
    }
