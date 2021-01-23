		public static bool VerifyToken(string token, ref CustomResponse customResponse, ref SecurityToken validatedToken, ref ClaimsPrincipal claimsPrincipal)
		{
				// This was the biggest challenge in finding the cert that is used to validate the token
		    var certString = "Found in the CallbackController.cs in the IdentityServer3.Samples repository"
		    var cert = new X509Certificate2(Convert.FromBase64String(certString));
				// Setting what you'd like the authorization to validate.
		    var validationParameters = new TokenValidationParameters()
		    {
		        IssuerSigningToken = new X509SecurityToken(cert),
		        ValidAudience = ConfigurationManager.AppSettings["IdentityServerUrl"] + "/resources",
		        ValidIssuer = ConfigurationManager.AppSettings["IdentityServerUrl"],
		        ValidateLifetime = true,
		        ValidateAudience = true,
		        ValidateIssuer = true,
		        ValidateIssuerSigningKey = true
		    };
		    var tokenHandler = new JwtSecurityTokenHandler();
		    try
		    {
		        claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
		    }
		    catch (SecurityTokenValidationException e)
		    {
		        //HttpContext.Current.Response.StatusCode = 401;
		        //statusCode = HttpStatusCode.Unauthorized;
		        customResponse = new CustomResponse();
		        customResponse.ServiceReturnStatus = new ServiceReturnStatus();
		        customResponse.ServiceReturnStatus.ReturnCode = -401;
		        customResponse.ServiceReturnStatus.ReturnMessage = "Unauthorized";
		    }
		    catch (Exception e)
		    {
		        //HttpContext.Current.Response.StatusCode = 403;
		        //statusCode = HttpStatusCode.InternalServerError;
		        customResponse = new CustomResponse();
		        customResponse.ServiceReturnStatus = new ServiceReturnStatus();
		        customResponse.ServiceReturnStatus.ReturnCode = -403;
		        customResponse.ServiceReturnStatus.ReturnMessage = "Internal Server Error";
		    }
		    //... manual validations return false if anything untoward is discovered
		    return validatedToken != null;
		}
		private string GetClaimFromPrincipal(ClaimsPrincipal principal, string claimType)
		{
		    var uidClaim = principal != null && principal.Claims != null ? principal.Claims.FirstOrDefault(s => s.Type == claimType) : null;
		    return uidClaim != null ? uidClaim.Value : null;
		}
