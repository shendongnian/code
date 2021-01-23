	// demo of controller calling your Provider
    public class SomeController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            var wrapper = this.ActionWrapper();
            var answerProvider = new AnswerProvider(wrapper);
            var result = await answerProvider.CreateAsync(model);
        }
    }
	// a simple extension on the ApiController
    public static class WrapperExtension
    {
        public static IActionWrapper ActionWrapper(this ApiController controller)
        {
            return new ApiActionWrapperContext(controller);
        }
    }
	// wrapped in interface so its easy to unit test the Provider
    public interface IActionWrapper
    {
        OkResult Ok();
        BadRequestResult BadRequest();
        BadRequestErrorMessageResult BadRequest(string message);
        OkNegotiatedContentResult<T> Ok<T>(T content);
    }
	// the implementation, this takes the current Controller and uses it as the context to return the same result types
	// only implemented Ok and BadRequest as a demo, you can extend it as needed
    public class ApiActionWrapperContext : IActionWrapper
    {
        private ApiController _controller;
        public ApiActionWrapperContext(ApiController controller)
        {
            _controller = controller;
        }
        public BadRequestResult BadRequest()
        {
            return new BadRequestResult(_controller);
        }
        public BadRequestErrorMessageResult BadRequest(string message)
        {
            return new BadRequestErrorMessageResult(message, _controller);
        }
        public OkResult Ok()
        {
            return new OkResult(_controller);
        }
        public OkNegotiatedContentResult<T> Ok<T>(T content)
        {
            return new OkNegotiatedContentResult<T>(content, _controller);
        }
    }
	
	// provider shortered with just some relevant code to demo
	// notice constructor, the new private field, and the use of it
    public class AnswerProvider
    {
        private IActionWrapper _actionWrapper;
        public AnswerProvider(IActionWrapper actionWrapper)
        {
            if(actionWrapper == null)
                throw new ArgumentNullException("actionWrapper");
            _actionWrapper = actionWrapper;
        }
        public async Task<IHttpActionResult> CreateAsync(AnswerRequestModel model)
        {
            try
            {
                // Validate our answer count
                await ValidateAnswerCountAsync(model.QuestionId);
                // Create our model
                var answer = ModelFactory.Create(model);
                // Add our images to our answer
                answer.Images = model.Images;
                // Save our model
                this._answerService.Create(answer);
                // Save the database changes
                await this._unitOfWork.SaveChangesAsync();
                // Return our updated model
                return this._actionWrapper.Ok(ModelFactory.Create(answer));
                // If there is an error
            }
            catch (Exception ex)
            {
                // Return our error
                return this._actionWrapper.BadRequest(ex.Message.ToString());
            }
        }
    }
