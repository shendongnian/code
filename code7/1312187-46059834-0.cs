        public class TestController:ApiController
        {
            public IHttpActionResult Delete(int id)
            {
                return ExecuteCommand(() => {
                    var command = new DeleteItemCommand() { Id = id };
                    _deleteCommandHandler.Handle(command);
                });
        }
        private IHttpActionResult ExecuteCommand(Action action)
        {
            return action.SafeInvoke();
        }
    }
    public static class ActionExtensions
    {
        private static readonly Dictionary<Type, HttpStatusCode> _exceptionToStatusCodeLookup = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(CommandHandlerResourceNotFoundException), HttpStatusCode.NotFound },
            {typeof(CommandHandlerException), HttpStatusCode.InternalServerError },
        };
        public static IHttpActionResult SafeInvoke(this Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var statusCode = _exceptionToStatusCodeLookup.ContainsKey(ex.GetType()) ? _exceptionToStatusCodeLookup[ex.GetType()] : HttpStatusCode.InternalServerError;
                return new HttpResponseException(statusCode);
            }
            return new OkResult();
        }
    }
