    public IEnumerable<Code> GetCodes()
    {
        var SelectedTags = new List<Tag>(); /* fill this however */
        return from code in GetAllCodes() /* get all codes*/
               where SelectedTags.All(code.Tags.Contains) /* filter out codes with nonmatching tags */
               select code; /* return the remaining codes */
    }
