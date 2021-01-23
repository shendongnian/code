    string MyRegEx = "";
    for(int i=0; i<input.Length; i++)
    {
        switch(input[i])
        {
            case 'a':
                MyRegEx += [aâà];
                break;
            case 'c':
                MyRegEx += [cč];
                break;
            ....
        }
    }
    System.Text.RegularExpressions.RegEx R = new System.Text.RegularExpressions.RegEx(MyRegEx);
    var Your Results = SuggestionsList.Where(s => R.IsMatch(s.ToLower()));
