        private string CreateToken(string name)
                    {
            
                        var key = this.HexToByte("... here is the same hexadecimal code that is specified in SecurityConfug.config file in securityTokenIssuers tag ... ");
            
                        var sb = new StringBuilder();
            
    // here I'm adding info from claims, only these two claims are needed
                        sb.AppendFormat("{0}={1}&", UrlEncode(ClaimTypes.Name), name);
                        sb.AppendFormat("{0}={1}&", UrlEncode("http://schemas.sitefinity.com/ws/2011/06/identity/claims/domain"), "Default");
            
                        sb
                            .AppendFormat("TokenId={0}&", UrlEncode(Guid.NewGuid().ToString()))
                            .AppendFormat("Issuer={0}&", UrlEncode("http://localhost"))
                            .AppendFormat("Audience={0}&", UrlEncode("http://localhost"))
                            .AppendFormat("ExpiresOn={0:0}", (DateTime.UtcNow.AddDays(1) - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds );
            
                        var unsignedToken = sb.ToString();
            
                        var hmac = new HMACSHA256(key);
                        var sig = hmac.ComputeHash(Encoding.ASCII.GetBytes(unsignedToken));
            
                        string signedToken = String.Format("{0}&HMACSHA256={1}",
                            unsignedToken,
                            UrlEncode(Convert.ToBase64String(sig)));
            
                        return signedToken;    
        
                    }
        
        private byte[] HexToByte(string hexString)
                {
                    byte[] returnBytes = new byte[hexString.Length / 2];
                    for (int i = 0; i < returnBytes.Length; i++)
                        returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
                    return returnBytes;
                }
