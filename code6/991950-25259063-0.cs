    public IEnumerable<Code> GetCodes()
    {
      //A collection to filter upon
      var SelectedTags = new List<Tag>();
      //the collction to return
      var FoundCodes = new List<Code>();
      foreach (var code in GetAllCodes())
      {
        foreach (var tags in code.Tags.Where(tags => SelectedTags.Contains(tags)))
        {
          if (!FoundCodes.Contains(code))
          {
            FoundCodes.Add(code);
          }
          continue;
        }
        foreach (var selectedTags in SelectedTags.Where(selectedTags => !code.Tags.Contains(selectedTags)))
        {
          FoundCodes.Remove(code);
        }
      }
      return FoundCodes;
    }
