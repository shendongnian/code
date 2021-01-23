    public static void M1(int a, int b, int c, int? d = null)
    {
        // working with a, b, c
    
        if (d == null)
            return;
    
        var dValue = (int)d; // casting the nullable int to int to work with
        // use the d parameter
    }
