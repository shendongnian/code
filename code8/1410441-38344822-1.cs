    public Class A
    {
        public static void main(string[] args)
        {
            String s = “hello”;
            String w = Changestring(s);
            String x = w; // if you assign s to x, you will just get "hello"
        }
    
        private string Changestring(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(s);
            sb.Append(“Hi”);
            return sb.ToString(); // "helloHi"
        }
    }   
