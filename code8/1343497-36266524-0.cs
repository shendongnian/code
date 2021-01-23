    [DataContract]
    public enum ErrorCode
    {
        Default,
        [EnumMember(Value = "invalid_number")]
        InvalidNumber,
        [EnumMember(Value = "invalid_expiry_month")]
        InvalidExpiryMonth,
        [JsonProperty("invalid_expiry_year")]
        InvalidExpiryYear,
        [EnumMember(Value = "invalid_cvc")]
        InvalidCvc,
        [EnumMember(Value = "incorrect_number")]
        IncorrectNumber,
        [EnumMember(Value = "expired_card")]
        ExpiredCard,
        [EnumMember(Value = "incorrect_cvc")]
        IncorrectCvc,
        [EnumMember(Value = "incorrect_zip")]
        IncorrectZip,
        [EnumMember(Value = "card_declined")]
        CardDeclined,
        [EnumMember(Value = "missing")]
        Missing,
        [EnumMember(Value = "processing_error")]
        ProcessingError
    }
    public class Error
    {
        public ErrorType type { get; set; }
        public string message { get; set; }
    }
    [DataContract]
    public enum ErrorType
    {
        Default,
        [EnumMember(Value = "api_connection_error")]
        ApiConnectionError,
        [EnumMember(Value = "api_error")]
        ApiError,
        [EnumMember(Value = "authentication_error")]
        AuthenticationError,
        [EnumMember(Value = "card_error")]
        CardError,
        [EnumMember(Value = "invalid_request_error")]
        InvalidRequestError,
        [EnumMember(Value = "rate_limit_error")]
        RateLimitError
    }
