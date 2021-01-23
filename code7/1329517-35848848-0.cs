          public class yourJsonWebTokenFormat: ISecureDataFormat<AuthenticationTicket>
            {
                public string Protect(AuthenticationTicket data)
                {
                DateTime notBefore = DateTime.UtcNow;
                DateTime expires = notBefore + TimeSpan.FromHours(1); //validity timer.
    
         SigningCredentials cred= new SigningCredentials(); // your signing credentials.
                    JwtHeader header = new JwtHeader(cred);
                    JwtPayload payload = newJwtPayload(ConfigurationManager.AppSettings["Issuer"],data.Properties.Dictionary["audience"], data.Identity.Claims, notBefore, expires);
        payload.add("x5t","your x5t to json property");
        
                    var jwtToken = new JwtSecurityToken(header, payload);
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.WriteToken(jwtToken);
                    return jwt;
                }
    }
