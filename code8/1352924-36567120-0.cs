        var tags = viewmodel.Tags.Split(',');
        // create old tag and new tag list
        var oldTags = new List<Tag>();
        var newTags = new List<Tag>();
        
        // check old and new tag and add it to list
        foreach (var tag in tags)
        {
            var testTag = await _context.Tag.FirstOrDefaultAsync(t => t.Text == tag);
            if (testTag != null)
            {
                oldTags.Add(testTag);
            }
            else
            {
                newTags.Add(new Tag { Text = tag });
            }
        }
        var grammaTagList = new List<GrammarTag>();
        oldTags.AddRange(newTags);
        
        // put every that in this Grammar to join table
        foreach (var tag in oldTags)
        {
            grammaTagList.Add(new GrammarTag { Tag = tag, Grammar = grammar });
        }
        _context.Grammar.Add(grammar);
        // add only the new tag
        _context.Tag.AddRange(newTags);
        _context.GrammarTag.AddRange(grammaTagList);
        await _context.SaveChangesAsync();
