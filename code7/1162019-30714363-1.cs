    private static int GetDifferenceCount(string firstName, string lastName)
    {
        int differences;
        string longestString = firstName;
        
        if (longestString.Length < lastName.Length)
            longestString = lastName;
        
        for (int i = 0; i < longestString.Length; i++)
        {
            try
            {
                if (firstName.Substring(i, 1) != lastName.Substring(i, 1))
                    differences++;
            }
            catch
                differences++;
        }
        return differences;
    }
