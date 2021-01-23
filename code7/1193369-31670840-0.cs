    int check = 0;
    foreach(var c in input)
    {
        if(c == '(')
            check++;
        if(c == ')')
            check--;
        if(check < 0)
            ... ; // error, closing bracket without opening brackets first
    }
    if(check == 0)
        ... ; // good
    else
        ...; // error, missing some closing brackets
    
