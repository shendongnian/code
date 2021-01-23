    public Threading.Tasks.Task ChallengeAsync(HttpAuthenticationChallengeContext context, Threading.CancellationToken cancellationToken)
    {
        context.Result = new AddRenewOnAauthorizedResult(context.Request, context.Result);
        return Task.FromResult(0);
    }
