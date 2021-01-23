    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Web;
    using System.Net;
    
    namespace MyNamespace
    {
        public class MyTokenRetrieverWithExtraStuff
        {
            public static async Task<Token> GetElibilityToken()
            {
                using (HttpClientHandler httpClientHandler = new HttpClientHandler())
                {
                    httpClientHandler.ServerCertificateCustomValidationCallback = CertificateValidationCallBack;
                    using (HttpClient client = new HttpClient(httpClientHandler))
                    {
                        return await GetElibilityToken(client);
                    }
                }
            }
    
            private static async Task<Token> GetElibilityToken(HttpClient client)
            {
                // throws certificate error if your cert is wired to localhost // 
                //string baseAddress = @"https://127.0.0.1/someapp/oauth2/token";
    
                //string baseAddress = @"https://localhost/someapp/oauth2/token";
    
            string baseAddress = @"https://blah.blah.blah.com/oauth2/token";
            string grant_type = "client_credentials";
            string client_id = "myId";
            string client_secret = "shhhhhhhhhhhhhhItsSecret";
            var form = new Dictionary<string, string>
                    {
                        {"grant_type", grant_type},
                        {"client_id", client_id},
                        {"client_secret", client_secret},
                    };
    
                HttpResponseMessage tokenResponse = await client.PostAsync(baseAddress, new FormUrlEncodedContent(form));
                var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                return tok;
            }
    
            private static bool CertificateValidationCallBack(
            object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                // If the certificate is a valid, signed certificate, return true.
                if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                {
                    return true;
                }
    
                // If there are errors in the certificate chain, look at each error to determine the cause.
                if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
                {
                    if (chain != null && chain.ChainStatus != null)
                    {
                        foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                        {
                            if ((certificate.Subject == certificate.Issuer) &&
                               (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                            {
                                // Self-signed certificates with an untrusted root are valid. 
                                continue;
                            }
                            else
                            {
                                if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                                {
                                    // If there are any other errors in the certificate chain, the certificate is invalid,
                                    // so the method returns false.
                                    return false;
                                }
                            }
                        }
                    }
    
                    // When processing reaches this line, the only errors in the certificate chain are 
                    // untrusted root errors for self-signed certificates. These certificates are valid
                    // for default Exchange server installations, so return true.
                    return true;
                }
    
    
                /* overcome localhost and 127.0.0.1 issue */
                if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch) != 0)
                {
                    if (certificate.Subject.Contains("localhost"))
                    {
                        HttpRequestMessage castSender = sender as HttpRequestMessage;
                        if (null != castSender)
                        {
                            if (castSender.RequestUri.Host.Contains("127.0.0.1"))
                            {
                                return true;
                            }
                        }
                    }
                }
    
                return false;
    
            }
    
    
            public class Token
            {
                [JsonProperty("access_token")]
                public string AccessToken { get; set; }
    
                [JsonProperty("token_type")]
                public string TokenType { get; set; }
    
                [JsonProperty("expires_in")]
                public int ExpiresIn { get; set; }
    
                [JsonProperty("refresh_token")]
                public string RefreshToken { get; set; }
            }
    
        }
    }
