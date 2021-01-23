        if (HttpContext.User.Identity is ClaimsIdentity identity)
            {
                identity.RemoveClaim(identity.FindFirst("userId"));
                identity.AddClaim(new Claim("userId", userInfo?.id.ToString()));
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(HttpContext.User.Identity));
            }
