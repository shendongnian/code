    public virtual async Task<JsonResult> Login(LoginViewModel loginModel, string returnUrl = "", string returnUrlHash = "")
    {
        var loginResult = await GetLoginResultAsync(loginModel.UsernameOrEmailAddress, loginModel.Password, loginModel.TenancyName);
        var tenantId = loginResult.Tenant == null ? (int?)null : loginResult.Tenant.Id;
        using (UnitOfWorkManager.Current.SetTenantId(tenantId))
        {
            if (loginResult.User.ShouldChangePasswordOnNextLogin)
            {
                loginResult.User.SetNewPasswordResetCode();
                return Json(new AjaxResponse
                {
                    TargetUrl = Url.Action(
                        "ResetPassword",
                        new ResetPasswordViewModel
                        {
                            TenantId = tenantId,
                            UserId = SimpleStringCipher.Instance.Encrypt(loginResult.User.Id.ToString()),
                            ResetCode = loginResult.User.PasswordResetCode
                        })
                });
            }
            var signInResult = await _signInManager.SignInOrTwoFactorAsync(loginResult, loginModel.RememberMe);
            if (signInResult == SignInStatus.RequiresVerification)
            {
                return Json(new AjaxResponse
                {
                    TargetUrl = Url.Action(
                        "SendSecurityCode",
                        new
                        {
                            returnUrl = returnUrl + (returnUrlHash ?? ""),
                            rememberMe = loginModel.RememberMe
                        })
                });
            }
            Debug.Assert(signInResult == SignInStatus.Success);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = GetAppHomeUrl();
            }
            if (!string.IsNullOrWhiteSpace(returnUrlHash))
            {
                returnUrl = returnUrl + returnUrlHash;
            }
            return Json(new AjaxResponse { TargetUrl = returnUrl });
        }
    }
