    // This is an implementation of FormUrlEncodedContent with `ISO-8859-1`
    public class FormIso8859Encoder : ByteArrayContent
    {
        public FormIso8859Encoder(IEnumerable<KeyValuePair<string, string>> nameValueCollection) : base(FormDataToByteArray(nameValueCollection))
        {
            
        }
        private static byte[] FormDataToByteArray(IEnumerable<KeyValuePair<string, string>> nameValueCollection)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (var nameValue in nameValueCollection)
            {
                if (sb.Length > 0)
                    sb.Append('&');
                sb.Append(nameValue.Key);
                sb.Append('=');
                // Here is the major change
                sb.Append(HttpUtility.UrlEncode(nameValue.Value, Encoding.GetEncoding("iso-8859-1") ));
            }
            return Encoding.Default.GetBytes(sb.ToString());
        }
    }
