    public IENumerable<Tag> SearchTags(IENumerable<string> toBeSearchedTags)
    {
		List<Tag> availableTags = new List<Tag>();
		foreach(var stag in toBeSearchedTags)
		{
		   var availableTag = _context.Tags.FirstOrdefault(tag => tag.Source.Equals(stag, StringComparison.CurrentCulture)) 
		   if(availableTag != null)
		   {
			  availableTags.Add(availableTag);
		   }
		}
		return availableTags;
    }
