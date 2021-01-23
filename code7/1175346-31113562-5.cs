    private static void Main(string[] args)
    {
        string[] mystr = null;
        if (IsNullOrEmpty(mystr))
        {
             //Do your thing
        }            
    }
     
    static bool IsNullOrEmpty(string[] strarray)
    {
        return strarray== null || strarray.Length == 1;
    }
