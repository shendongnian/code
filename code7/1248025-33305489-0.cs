    string input = "0, Link Alive,1, Link Dead,2, Link Weak,3, Wiznet 0 Dead,4, Wiznet 1 Dead,5, Wiznets Dead"
    string[] parts = input.split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
    foreach (string part in parts)
    {
        // do something
    }
