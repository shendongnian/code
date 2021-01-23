    class FormActionEventArgs : EventArgs
    {
        public FormActions Action { get; private set; }
        public string TextToDisplay { get; private set; }
        public FormActionEventArgs(FormActions action, string textToDisplay)
        {
            Action = action;
            TextToDisplay = textToDisplay;
        }
    }
    public event EventHandler<FormActionEventArgs> FormAction;
    private void MyMarshalDataToForm(FormActions action, String textToDisplay)
    {
        try
        {
            FormActionEventArgs args = new FormActionEventArgs(action, textToDisplay);
    
            //  The AccessForm routine contains the code that accesses the form.
    
            EventHandler<FormActionEventArgs> marshalDataToFormDelegate = FormAction;
    
            //  Execute AccessForm, passing the parameters in args.
    
            if (marshalDataToFormDelegate != null)
            {
                Dispatcher.Invoke(marshalDataToFormDelegate, this, args);
            }
        }
        catch (Exception ex)
        {
            DisplayException(Name, ex);
            throw;
        }
    }
