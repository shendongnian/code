    public async override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var controller = (ControllerBase)filterContext.Controller;
        if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
        {
            if (!(await IsAuthorized(filterContext.HttpContext, controller)))
            {
                filterContext.Result = new HttpStatusCodeResult(401);
            }
        }
        else
        {
            //TODO check access rights
        }
    }
    private async Task<bool> IsAuthorized(HttpContext context, ControllerBase controller)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.Headers.Add("WWW-Authenticate", "NTLM");
            return false;
        }
        var header = context.Request.Headers["Authorization"][0].Substring(5);
        var message = System.Text.Encoding.ASCII.GetString(
                          Convert.FromBase64String(header));
        if (!message.StartsWith("NTLMSSP"))
        {
            return false;
        }
        //type 1 message received
        if (message[8] == '\x01')
        {
            byte[] type2Message =
            {
                0x4e, 0x54, 0x4c, 0x4d, 0x53, 0x53, 0x50, 0x00,//Signature
                0x02, 0x00, 0x00, 0x00, //Type 2 Indicator
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, //Security Buffer
                0x01, 0x02, 0x81, 0x00, //Flags
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, //Challenge
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, //Context
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 //Target info
            };
            context.Response.Headers.Add("WWW-Authenticate", "NTLM "
                + Convert.ToBase64String(type2Message));
            return false;
        }
        //type 3 message received
        else if (message[8] == '\x03')
        {
            var userName = GetMessageString(message, 36);
            var domainName = GetMessageString(message, 28);
            var workstation = GetMessageString(message, 44);
            var user = controller.DbContext.Users.FirstOrDefault(
                          u => u.WindowsAccount.ToLower() == userName.ToLower());
            if (user != null)
            {
                var identity = new ClaimsIdentity();
                identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                context.User.AddIdentity(identity);
                try
                {
                    await controller.SignInManager.SignInAsync(user, false);
                }
                catch { }
                return true;
            }
        }
        return false;
    }
    private string GetMessageString(string message, int start, bool unicode = true)
    {
        var length = message[start + 1] * 256 + message[start];
        var offset = message[start + 5] * 256 + message[start + 4];
        if (unicode)
            return message.Substring(offset, length).Replace("\0", "");
        else
            return message.Substring(offset, length);
    }
