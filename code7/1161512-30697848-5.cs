    public static int WordCount(this String str)
    {
        return str.Split(new char[] { ' ', '.', '?' }, 
                         StringSplitOptions.RemoveEmptyEntries).Length;
    }
