    private ActionCommand deleteCommand = new ActionCommand(action => DeleteCommand(AudioTrack),
        canExecute => CanDelete(AudioTrack)); 
    public override ICommand Delete
    {
        get { return deleteCommand; }
    }
    private void DeleteCommand(AudioTrack audioTrack)
    {
        // Do work then add to Stack in CommandManager
        CommandManager.AddCommand(deleteCommand);
    }
    private bool CanDelete(AudioTrack audioTrack)
    {
        return audioTrack != null;
    }
