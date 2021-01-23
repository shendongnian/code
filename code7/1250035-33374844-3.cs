    int count = 1;
    int len = input.Length - 1;
    for(int i = 0; i < len; ++i)
      switch(input[i])
      {
        case '\r':
        if (input[i + 1] == '\n')
        {
          if (++i >= len)
          {
            break;
          }
        }
        goto case '\n';
            case '\n':
            // Uncomment below to include all other line break sequences
            // case '\u000A':
            // case '\v':
            // case '\f':
            // case '\u0085':
            // case '\u2028':
            // case '\u2029':
              ++count;
              break;      
      }
