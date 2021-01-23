     public bool VerifyTextPresent(By by, String actual)
    {
            WaitUntilElementIsPresent(by);
            String expected = GetText(by);
            if (expected.Equals(actual)) return true;
            if (expected.Equals(Normalize(actual))) return true;
            return false;
    }
    private string Normalize(string s)
    {
        // hard-code for now; could use a lookup table or other means to expand  
        s = s.Replace((char)160, (char)32);
        // other replacements as necessary
   
        return s;
    }  
