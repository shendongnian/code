    public string CreateHashSignature(string strMozAccessId, string strMozSecretKey, string strTimeStamp)
        {
            string token = strMozAccessId + Environment.NewLine.Replace("\r", "") + strTimeStamp;
            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(strMozSecretKey), true))
            {
                var hash = hmac.ComputeHash(Encoding.ASCII.GetBytes(token));
                var hashString = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return HttpUtility.UrlEncode(Convert.ToBase64String(hash));
            }
        }
