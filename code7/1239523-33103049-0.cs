    public class CaseInsensitiveString : IEquatable<CaseInsensitiveString>
    {
        private string normalized = "";
        
        public CaseInsensitiveString(string str)
        {
            this.normalized = Normalize(str);
        }
        public CaseInsensitiveString()
        {
             this.Normalize = Normalize(null);
        }
    }
