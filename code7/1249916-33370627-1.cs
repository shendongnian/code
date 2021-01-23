    using (StreamReader sr = File.OpenText(path)) 
    {
        string s;
        while ((s = sr.ReadLine()) != null) 
        {
            // How would I go about reading line number and store first 5 
            // digits in different variable and next 6 digits to another variable.
            string first = s.Substring(0, 5);
            string second = s.Substring(6, 6);
        }
    }
