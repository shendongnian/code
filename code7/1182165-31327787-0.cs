    if (playlist is IList<IMusicItem>)
    {
      (playList as IList<IMusicItem>).AddRange(items);
    } 
    else
    {
       // still need a foreach here
    }
