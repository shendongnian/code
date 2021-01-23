    public class SampleController
    {
        private IUserManager _userManager;
        public ActionResult ValidateResetHash(string passwordResetHash)
        {
            Response    result      = this._userManager.IsValidPasswordResetHash(passwordResetHash);
            var         resultType  = SampleResponses.TrySelect(result.name, SampleResponses.Default);
            return resultType.GenerateView(result);
        }
    }
