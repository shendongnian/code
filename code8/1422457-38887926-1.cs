    public class MultiTentantBotAuthenticationAttribute : BotAuthentication
    {
        public override async Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            this.MicrosoftAppId = actionContext.Request.RequestUri.Segments.Last();
            await base.OnAuthorizationAsync(actionContext, cancellationToken);
        }
    }
