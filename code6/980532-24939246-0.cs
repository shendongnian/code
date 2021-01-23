    public class Pop3ClientExt : Pop3Client
    {
        public string Authenticate(string username, string password)
        {
            var nullchar = '\u0000';
            var auth = nullchar + username + nullchar + password;
            this.Command("auth plain");
            string response = this.Command(System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("iso-8859-1").GetBytes(auth)));
            return response;
        }
    }
