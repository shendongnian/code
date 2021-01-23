    public static class ListViewExt
    {
      public ListViewGroup GetGroup(this ListView view, string groupLabel)
      {
        var group = view.Groups[groupLabel];
        if (group == null)
        {   // group did not exist - let's create it and add it to the view
            group = new ListViewGroup(groupLabel);
            view.Groups.Add(group);
        }   
        return group; 
      }
    }
