    ConversionState state = ConversationState.Active;
    for(int i = 0; i < source.Length; i ++)
    {
      switch(state)
      {
        case ConversationState.Active:
          state = ConversionState.Name; 
          name += source[i]; 
          break;
        case ConversationState.Inactive:
          if(source[i] == ' ') 
          {
            name = name.ToLower();
            if(name[0] == '/')
              name = name.SubString(1);
            state = ConversionState.Between;
          }
          else
            name += source[i];
          break;
    }
