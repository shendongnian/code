    public class NotAllowedOkResult<T> : OkNegotiatedContentResult<T>
    {
        public NotAllowedOkResult(T content, ApiController controller, StatusReason statusReason)
            : base(content, controller)
        {
            statusReasonCode = statusReason;
        }
        public NotAllowedOkResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request,
            IEnumerable<MediaTypeFormatter> formatters, StatusReason statusReason)
            : base(content, contentNegotiator, request, formatters)
        {
            statusReasonCode = statusReason;
        }
        protected StatusReason statusReasonCode { get; set; }
        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.ExecuteAsync(cancellationToken);
            response.ReasonPhrase = GetStatusText(statusReasonCode);
            return response;
        }
        private static String GetStatusText(StatusReason reasonCode)
        {
            var retVal = "Unknown";
            switch (reasonCode)
            {
                case StatusReason.StatusFiltered:
                    retVal = "Filtered";
                    break;
            }
            return retVal;
        }
    }
