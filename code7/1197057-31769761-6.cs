    public abstract class ValidateHashResponses : ResponseEnum<ValidateHashResponses>
    {
        public static readonly ValidateHashResponses HashOk                   = HashValidatedResponse.instance;
        public static readonly ValidateHashResponses PasswordResetHashExpired = PasswordResetHashExpiredResponse.instance;
        public static readonly ValidateHashResponses Default                  = DefaultResponse.instance;
        private ValidateHashResponses(string responseName) : base(responseName) {}
        protected class HashValidatedResponse : ValidateHashResponses
        {
            public static HashValidatedResponse instance = new HashValidatedResponse();
            private HashValidatedResponse() : base("HashValidated") {}
            public override ActionResult GenerateView(Response response)
            {
                GenericActionModel responseModel = new GenericActionModel(true, "/Login", "Login", "You have submitted an invalid password reset link.", false);
                return new ActionResult("~/Views/Shared/GenericAction.cshtml", responseModel);
            }
        }
        protected class PasswordResetHashExpiredResponse : ValidateHashResponses
        {
            public static PasswordResetHashExpiredResponse instance = new PasswordResetHashExpiredResponse();
            private PasswordResetHashExpiredResponse() : base("PasswordResetHashExpired") {}
            public override ActionResult GenerateView(Response response)
            {
                GenericActionModel responseModel = new GenericActionModel(true, "/ResetPassword", "Reset Password", "You have submitted an expired password reset link. You must reset your password again to change it.", false);
                return new ActionResult("~/Views/Shared/GenericAction.cshtml", responseModel);
            }
        }
        protected class DefaultResponse : ValidateHashResponses
        {
            public static DefaultResponse instance = new DefaultResponse();
            private DefaultResponse() : base("Default") {}
            public override ActionResult GenerateView(Response response)
            {
                GenericActionModel responseModel = new GenericActionModel(true, "/", "Home", "An unknown error has occured. The system administrator has been notified. Error code:" + response.name, false);
                return new ActionResult("~/Views/Shared/GenericAction.cshtml", responseModel);
            }
        }
    }
