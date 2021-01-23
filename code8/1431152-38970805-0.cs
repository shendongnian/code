    public static string formatToken(string token)
        {
            //To prevent null exception
            if (string.IsNullOrWhiteSpace(token)) return token;
            Regex rgx = new Regex("[^a-zA-Z0-9 .,'()?!#$%*;:+=-_]"); //Maybe some characters need to be scaped. 
            return rgx.Replace(token, "");
        }
