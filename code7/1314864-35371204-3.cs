    public ICommand AttachmentChecked
    {
        get
        {
            return _attachmentChecked ?? (_attachmentChecked = new CommandHandler(param => ExecuteAttachmentChecked(param), CanExecuteAttachmentChecked()));
        }
    }
    private void ExecuteAttachmentChecked(object param)
    {
     //param will the value of `CommandParameter` sent from Binding
    }
    private bool CanExecuteAttachmentChecked()
    {
        return true;
    }
