    /// <summary>
    /// Call this when the CanExecute of the command has changed, this allows things like UI to update.
    /// </summary>
    public void ExecuteChanged()
    {
       CanExecuteChanged?.Invoke( this, EventArgs.Empty );
    }
