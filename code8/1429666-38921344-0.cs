    public static string Escape(string str){
        return str.Replace("&", "&amp;")
                  .Replace(">", "&gt;")
                  .Replace("\"", "&quot;")
                  .Replace("\'", "&apos;")
                  .Replace("<", "&lt;");
    }
