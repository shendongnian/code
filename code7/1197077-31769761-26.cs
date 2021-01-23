    public abstract class ValidateHashResponses : ResponseEnum<ValidateHashResponses>
    {
        public static readonly ValidateHashResponses HashOk                     = HashValidatedResponse.instance;
        public static readonly ValidateHashResponses InvalidHash                = InvalidHashResponse.instance;
        public static readonly ValidateHashResponses PasswordResetHashExpired   = PasswordResetHashExpiredResponse.instance;
        public static readonly ValidateHashResponses Default                    = DefaultResponse.instance;
        private ValidateHashResponses(string responseName) : base(responseName) {}
        protected abstract class ValidateHashResponse<TValidateHashResponse, TResponse> : ValidateHashResponses
            where TValidateHashResponse : ValidateHashResponse<TValidateHashResponse, TResponse>, new()
            where TResponse : Response<TResponse>
        {
            public static TValidateHashResponse instance = new TValidateHashResponse();
            private static string name = Response<TResponse>.Name;
            protected ValidateHashResponse() : base(name) {}
        }
        protected class HashValidatedResponse : ValidateHashResponse<HashValidatedResponse, HashValidated>
        {
            public override ActionResult GenerateView(Response response)
            {
                PasswordChangeModel model = new PasswordChangeModel();
                model.PasswordResetHash = ((HashValidated) response).passwordResetHash;
                return new ActionResult("~/Areas/Public/Views/ResetPassword/PasswordChangeForm.cshtml", model);
            }
        }
        protected class InvalidHashResponse : ValidateHashResponse<InvalidHashResponse, InvalidHash>
        {
            public override ActionResult GenerateView(Response response)
            {
                GenericActionModel responseModel = new GenericActionModel(true, "/Login", "Login", "You have submitted an invalid password reset link.", false);
                return new ActionResult("~/Views/Shared/GenericAction.cshtml", responseModel);
            }
        }
        protected class PasswordResetHashExpiredResponse : ValidateHashResponse<PasswordResetHashExpiredResponse, PasswordResetHashExpired>
        {
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
