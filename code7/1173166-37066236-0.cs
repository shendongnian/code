    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens;
    using System.Linq;
    using System.Net.Http;
    using System.Web;
    using System.Web.Configuration;
    using Newtonsoft.Json;
    using System.Net;
    using System.Threading.Tasks;
    using System.Threading;
    using Services.Models;
    using System.Security.Claims;
    
    namespace Services
    {
        /// <summary>
        ///  This is an implementation of Google JWT verification that
        ///  demonstrates:
        ///    - JWT validation
        /// </summary>
        /// @author kunal.bajpai@gmail.com (Kunal Bajpai)
    
    
        public class CustomJwtHandler : DelegatingHandler
        {
            string issuer = WebConfigurationManager.AppSettings["GoogleDomain"];
            string audience = WebConfigurationManager.AppSettings["GoogleClientId"];
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="request"></param>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                HttpStatusCode statusCode;
                string token;
    
                var authHeader = request.Headers.Authorization;
                if (authHeader == null)
                {
                    // Missing authorization header
                    return base.SendAsync(request, cancellationToken);
                }
    
                if (!TryRetrieveToken(request, out token))
                {
                    return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }
    
                try
                {
                    ValidateToken(token);
                    return base.SendAsync(request, cancellationToken);
                }
                catch (SecurityTokenInvalidAudienceException)
                {
                    statusCode = HttpStatusCode.Unauthorized;
                }
                catch (SecurityTokenValidationException)
                {
                    statusCode = HttpStatusCode.Unauthorized;
                }
                catch (Exception e)
                {
                    statusCode = HttpStatusCode.InternalServerError;
                }
    
                return Task<HttpResponseMessage>.Factory.StartNew(() => new HttpResponseMessage(statusCode));
            }
            /// <summary>
            /// Validates JWT Token
            /// </summary>
            /// <param name="token"></param>
            private void ValidateToken(string token)
            {
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        TokenInfo tokenInfo = JsonConvert.DeserializeObject<TokenInfo>(wc.DownloadString("https://www.googleapis.com/oauth2/v3/tokeninfo?id_token=" + token));
    
                        List<Claim> claims = new List<Claim> {
                            new Claim(ClaimTypes.Name, tokenInfo.Name),
                            new Claim(ClaimTypes.Email, tokenInfo.Email),
                            new Claim(ClaimTypes.GivenName, tokenInfo.GivenName),
                            new Claim(ClaimTypes.Surname, tokenInfo.FamilyName),
                        };
    
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, tokenInfo.Issuer));
                        Thread.CurrentPrincipal = claimsPrincipal;
                        HttpContext.Current.User = claimsPrincipal;
                    }
                }
                catch (WebException e)
                {
                    HttpStatusCode statusCode = ((HttpWebResponse)e.Response).StatusCode;
                    if (statusCode == HttpStatusCode.BadRequest)
                    {
                        throw new SecurityTokenValidationException();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            /// <summary>
            /// Tries to retrieve Token
            /// </summary>
            /// <param name="request"></param>
            /// <param name="token"></param>
            /// <returns></returns>
            private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
            {
                token = null;
                IEnumerable<string> authorizationHeaders;
    
                if (!request.Headers.TryGetValues("Authorization", out authorizationHeaders) ||
                authorizationHeaders.Count() > 1)
                {
                    return false;
                }
    
                var bearerToken = authorizationHeaders.ElementAt(0);
                token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
                return true;
            }
        }
    }
