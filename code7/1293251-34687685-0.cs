        string input = @"heya's #FFFFF , CUL8R M8 how are you?'"; // This is the input string
    string regex = @"[!""#$%&'()*+,\-./:;<=>?@[\\\]^_`{|}~]"; //Banned characters string, add all characters you don´t want to be displayed here.
    
    
    Match m;
    
    while ((m = Regex.Match(input, regex)) != null)
    {
        if (m.Success) 
            input = input.Remove(m.Index, m.Length);
        else // if m.Success is false: break, because while loop can be infinite
            break;
    }
    input = input.Replace("  ", " ").Replace("  "," "); //if string has two-three-four spaces together change it to one
    MessageBox.Show(input);
