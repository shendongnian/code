    private List<UndoTrack> trackUndoHistory = new List<UndoTrack>();
    public void BeginEditing()
    {
        // determine the track being edited.
        // .....
        trackUndoHistory.Add(new UndoTrack(trackBeingEdited));
    }
