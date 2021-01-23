    public FormsAuthenticationTicket Ticket
    {
        get
        {
            return new Lazy<FormsAuthenticationTicket>(() =>
                {
                    var ck =
                        Helper.Context.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (ck != null)
                    {
                        return FormsAuthentication.Decrypt(ck.Value);
                    }
                    return null;
                }).Value;
        }
    }
