    private MyAdd(string line, int index)
    {
       if(index == 11)
          Items.Add(new ItemProperties {Item = line, Description = "line11"});
       else
          Items.Add(new ItemProperties {Item = line, Description = "other"});
    }
