    public static class ApiControllerExtensions {
        public static IHttpActionResult BadRequest<T>(this ApiController controller, T content) {
            return controller.CustomResponse(HttpStatusCode.BadRequest, content);
        }
        public static IHttpActionResult NotFound<T>(this ApiController controller, T content) {
            return controller.CustomResponse(HttpStatusCode.NotFound, content);
        }
        public static IHttpActionResult CustomResponse<T>(this ApiController controller, HttpStatusCode statusCode, T content) {
            var request = controller.Request;
            var result = new CustomResponseResult<T>(statusCode, content, request);
            return result;
        }
    }
