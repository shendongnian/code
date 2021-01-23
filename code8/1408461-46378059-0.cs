    public class CustomAccessTokenProvider : AuthenticationTokenProvider
    {
        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
            var expired = context.Ticket.Properties.ExpiresUtc < DateTime.UtcNow;
            if (expired)
            {
                //If current token is expired, set a custom response header
                context.Response.Headers.Add("X-AccessTokenExpired", new string[] { "1" });
            }
    
            base.Receive(context);
        }
    }
