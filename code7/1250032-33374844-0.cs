    int count = 0;
    int len = input.Length;
    for(int i = 0; i != len; ++i)
      switch(input[i])
      {
        case '\r':
          ++count;
          if (i + 1 != len && input[i + 1] == '\n')
            ++i;
          break;
        case '\n':
        // Uncomment below to include all other line break sequences
        // case '\u000A':
        // case '\v':
        // case '\f':
        // case '\u0085':
        // case '\u2028':
        // case '\u2029':
          ++count;
      }
