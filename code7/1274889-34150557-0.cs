    public class FooController : ApiController
    {
        [HttpPost]
        public IHttpActionResult PostForm(FormInput input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // You'll have to create the repository class as well as inject it
            // into your controller. If you don't know what I'm talking about,
            // google "dependency injection asp.net webapi" for more info.
            _repository.SaveFormDataToDb(input.Field1, input.Field2);
            return Ok();
        }
    }
