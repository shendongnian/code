    /// <summary>
    /// An <see cref="ObjectResult"/> that when executed will produce a Request Timeout (408) response.
    /// </summary>
    [DefaultStatusCode(DefaultStatusCode)]
    public class TimeoutExceptionObjectResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status408RequestTimeout;
        /// <summary>
        /// Creates a new <see cref="TimeoutExceptionObjectResult"/> instance.
        /// </summary>
        /// <param name="error">Contains the errors to be returned to the client.</param>
        public TimeoutExceptionObjectResult(object error)
            : base(error)
        {
            StatusCode = DefaultStatusCode;
        }
    }
