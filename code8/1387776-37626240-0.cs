        private ApplicationUser _currentUser;
        private ApplicationUserManager _manager;
        protected ApplicationUserManager Manager
        {
            get { return _manager ?? (_manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>()); }
        }
        protected ApplicationUser CurrentUser
        {
            get { return _currentUser ?? (_currentUser = Manager.FindById(User.Identity.GetUserId())); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser == null || !User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/account/register.aspx");
            }
            else if (User.Identity.IsAuthenticated && CurrentUser.EmailConfirmed)
            {
                alreadyConfirmed.Visible = true;
            }
            else if (!minTimeElapsedSinceLastRequest())
            {
                NotEnoughTimeLiteral.Text = "A resend occurred on " + CurrentUser.PhoneNumber + ". Please wait longer before your next request";
                notEnoughTimeFlag.Visible = true;
            }
            else
            {
                idResendButton.Enabled = true;
            }
        }
        protected void ResendConfirmationEmailClick(object sender, EventArgs e)
        {
            string currentUserId = User.Identity.GetUserId();
            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            string code = Manager.GenerateEmailConfirmationToken(currentUserId);
            string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, currentUserId, Request);
            Manager.SendEmail(currentUserId, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
            setUsersLastResendDateTime(CurrentUser);
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
