        public static string getSaSToken()
        {
            TimeSpan fromEpochStart = DateTime.UtcNow - new DateTime(1970, 1, 1);
            string expiry = Convert.ToString((int)fromEpochStart.TotalSeconds + 3600);
            string baseAddress = "XYZABCBLAH.azure-devices.net/devices/12345".ToLower();
            string stringToSign = WebUtility.UrlEncode(baseAddress).ToLower() + "\n" + expiry;
            byte[] data = Convert.FromBase64String("y2moreblahblahblah=");
            HMACSHA256 hmac = new HMACSHA256(data);
            byte[] poo = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
            string signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            string token = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}",
                            WebUtility.UrlEncode(baseAddress).ToLower(), WebUtility.UrlEncode(signature), expiry);
            return token;
        }
