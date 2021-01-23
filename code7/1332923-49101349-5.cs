    public List<TControlType> FindByPattern<TControlType>(string regexPattern)
      where TControlType:Control
    {
       return Controls.OfType<TControlType>()
                      .Where(control => Regex.IsMatch(control.Name, regexPattern))
                      .ToList();
    }
