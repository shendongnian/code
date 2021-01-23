    var isPersistent = false;
            var authCookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                isPersistent = ticket.IsPersistent;
            }
