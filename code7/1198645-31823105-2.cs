    IList<NoteModel2> partial3 = new List<NoteModel2>();
    foreach (var i in partial)
    {
        partial3.Add(new NoteModel2
        {
            ID = i.ID,
            Note1 = i.Note1,
            Note2 = Regex.Replace(i.Note1.Trim(), @"<(.|\n)*?>", string.Empty),
            Rank = (int)i.Rank
        });
    }
    IList<NoteModel2> notes;
    if (sort == "none")
    {
        notes = partial.OrderBy(x => x.Rank).OrderBy(x => x.Stat).OrderByDescending(x => x.Note_Strength_Value).Skip(startIndex).Take(BlockSize).ToList();
    
    }
    if (sort == "ascending")
    {
        notes = partial3.OrderBy(x => x.Note2).Skip(startIndex).Take(BlockSize).ToList();        
    }
    else
    {
        notes = partial3.OrderByDescending(x => x.Note2).Skip(startIndex).Take(BlockSize).ToList();    
    }
    NoteList.Clear();
    if (notes.Count() > 0)
    {
        foreach (var item in notes)
        {
            NoteList.Add(new NoteModel
            {
                Note1 = "<tr id=\"" + item.ID + "\" class=\"trPregame\"><td style=\"text-align:left; width:100%;\" id=\"notesonly\">" + item.Note1 + "</td></tr>",
            });
        }
    }
    else
    {
        NoteList.Add(new NoteModel
        {
            Note1 = "<tr id=\"noresult\"><td colspan=\"1\" style=\"text-align:center\"><b>No Results Found!</b></td></tr>"
        });
    }
