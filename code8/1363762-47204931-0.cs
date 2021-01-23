     public string ComputeHMAC(string message)
        {
            var keyBytes = Encoding.UTF8.GetBytes(Constants.API_KEY);
            var messageBytes = Encoding.UTF8.GetBytes(message);
            var hmac = new HMACSHA256(keyBytes);
            byte[] result = hmac.ComputeHash(messageBytes);
            return Convert.ToBase64String(result);
        }
