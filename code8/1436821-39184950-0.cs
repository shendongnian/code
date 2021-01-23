        private readonly AuthenticationProperties authenticationProperties;
        private readonly string[] authenticationSchemes;
        private readonly ChallengeBehavior challengeBehavior;
        public MyChallengeResult(
            AuthenticationProperties authenticationProperties,
            ChallengeBehavior challengeBehavior,
            string[] authenticationSchemes)
        {
            this.authenticationProperties = authenticationProperties;
            this.challengeBehavior = challengeBehavior;
            this.authenticationSchemes = authenticationSchemes;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            AuthenticationManager authenticationManager =
                context.HttpContext.Authentication;
            foreach (string scheme in authenticationSchemes)
            {
                await authenticationManager.ChallengeAsync(
                    scheme,
                    authenticationProperties,
                    challengeBehavior);
            }
        }
    }
