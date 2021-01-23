    public string[] Replace(string[] page, string[] notes, int start, int length)
    {
      for(var i = 0; i + start < page.Length && i < length; i++)
      {
        if(notes != null && notes.Length > (i))
          page[i+start] = notes[i];
        else
          page[i+start] = Enviroment.NewLine;
      }
    
      return page;
    }
