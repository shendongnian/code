    private void x()
    {
        string sTestFile = "this is a test";   
        string[] TestFileWords;
        FixConcatString(sTestFile, out TestFileWords);
    }
   
    private void FixConcatString(string splayfile, **out** string[] sWordArray)
    {
        char[] charSeparators = new char[] { '-' };
        splayfile = splayfile.ToLower();
        splayfile = splayfile.Replace(@"\", " ");
        sWordArray =  splayfile.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
    }
