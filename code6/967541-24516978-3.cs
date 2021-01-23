     public static class UserCookie
        {
            public static HttpCookie GetCookie(User user)
            {
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel { user_id = user.UserId, username = user.Username, roles = user.Roles ,session_token =  GUIDGenerator.ToAlphaNumerical() };
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string userData = serializer.Serialize(serializeModel);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                   user.UserId.ToString(),
                   DateTime.Now,
                   DateTime.Now.AddMinutes(30),
                   false,
                   userData);
    
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                return  new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            }
        }
