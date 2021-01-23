    public dynamic GetNotesWithNoSpamCommentsCount()
    {
        var notesDTO = _notesRepository.GetNotes()
            .Select(x =>
            new 
            {
                Note = x,
                NoteCommentsCount = x.Comments.Where(y => y.IsSpam == false).Count()
            });
    
        return notesDTO;
    }
