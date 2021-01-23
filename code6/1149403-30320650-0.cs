    public static string xorIt(string email, string url)
    {
     StringBuilder sb = new StringBuilder();
     for(int i=0; i < input.Length; i++)
         sb.Append((char)(url[i] ^ email[(i % key.Length)]));
     String result = sb.ToString ();
     
     return result;
    }
