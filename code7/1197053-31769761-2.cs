    public abstract class SampleResponses : ResponseEnum<SampleResponses>
    {
        public static readonly SampleResponses SampleNotFound           = SampleNotFoundResponse.instance;
        public static readonly SampleResponses PasswordResetHashExpired = SampleNotFoundResponse.instance;
        public static readonly SampleResponses Default                  = SampleNotFoundResponse.instance;
        private SampleResponses(string responseName) : base(responseName) {}
        protected class SampleNotFoundResponse : SampleResponses
        {
            public static SampleNotFoundResponse instance = new SampleNotFoundResponse();
            private SampleNotFoundResponse() : base("SampleNotFound") {}
            public override ActionResult GenerateView(Response response)
            {
                GenericActionModel responseModel = new GenericActionModel(true, "/Login", "Login", "You have submitted an invalid password reset link.", false);
                return new ActionResult("~/Views/Shared/GenericAction.cshtml", responseModel);
            }
        }
        protected class PasswordResetHashExpiredResponse : SampleResponses
        {
            public static PasswordResetHashExpiredResponse instance = new PasswordResetHashExpiredResponse();
            private PasswordResetHashExpiredResponse() : base("PasswordResetHashExpired") {}
            public override ActionResult GenerateView(Response response)
            {
                GenericActionModel responseModel = new GenericActionModel(true, "/ResetPassword", "Reset Password", "You have submitted an expired password reset link. You must reset your password again to change it.", false);
                return new ActionResult("~/Views/Shared/GenericAction.cshtml", responseModel);
            }
        }
        protected class DefaultResponse : SampleResponses
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
