    /// <summary>
        /// Turn a URL encoded base64 encoded string into readable UTF-8 string.
        /// </summary>
        /// <param name="sInput">base64 URL ENCODED string.</param>
        /// <returns>UTF-8 formatted string</returns>
        private string DecodeURLEncodedBase64EncodedString(string sInput)
        {
            string sBase46codedBody = sInput.Replace("-", "+").Replace("_", "/").Replace("=", String.Empty);  //get rid of URL encoding, and pull any current padding off.
            string sPaddedBase46codedBody = sBase46codedBody.PadRight(sBase46codedBody.Length + (4 - sBase46codedBody.Length % 4) % 4, '=');  //re-pad the string so it is correct length.
            byte[] data = Convert.FromBase64String(sPaddedBase46codedBody);
            return Encoding.UTF8.GetString(data);
        }
