    bool odd = false;
    char replacementDelimiter = "|"; // Or some very unlikely character
    for(int i = 0; i < str.len; ++i)
    {
       if(str[i] == '\"')
           odd = !odd;
       else if (str[i] == ',')
       {
          if(!odd)
              str[i] = replacementDelimiter;
       }
    }
    string[] commaSeparatedTokens = str.Split(replacementDelimiter);
