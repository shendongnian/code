    public bool AreStrinEqualAsNumber(string num1, string num2)
    {
        if (n1 == null ||n2 == null)
            return false;
            
        // remove padded zero's from both the number.
        var n1 = num1.TrimStart('0');
        var n2 = num2.TrimStart('0');
        
        // if after removing zero's the length are not equal the numbers cant be equal.
        if (n1.Length != n2.Length)
            return false;
            
        // do a character by character comparision
        for(int i = 0; i < n1.Length; i++)
        {
            // number cant be equal if characters differ.
            if (n1[i] != n2[i])
                return false;
        }
        // no different character was found.
        return true;
    }
