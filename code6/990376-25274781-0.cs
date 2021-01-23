    public static class Key
    {       
        public static string EncryptWithAPurpose(this string expression, string[] purpose)
        {
            if (string.IsNullOrEmpty(expression))
                return string.Empty;
            byte[] stream = Encoding.Unicode.GetBytes(expression);
            byte[] encodedValue = MachineKey.Protect(stream, purpose);
            return HttpServerUtility.UrlTokenEncode(encodedValue);
        }
        public static string DecryptWithAPurpose(this string expression, string[] purpose)
        {
            if (string.IsNullOrEmpty(expression))
                return string.Empty;
            byte[] stream = HttpServerUtility.UrlTokenDecode(expression);
            
            byte[] decodedValue = MachineKey.Unprotect(stream,purpose);
            return Encoding.Unicode.GetString(decodedValue);
        }
    }
