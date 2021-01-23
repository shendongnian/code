    public class SampleController
    {
        private IUserManager _userManager;
        public ActionResult ValidateResetHash(string passwordResetHash)
        {
            Response    result      = this._userManager.IsValidPasswordResetHash(passwordResetHash);
            var         resultType  = ValidateHashResponses.TrySelect(result.name,ValidateHashResponses.Default);
            return resultType.GenerateView(result);
        }
    }
