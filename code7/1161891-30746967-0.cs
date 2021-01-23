    public delegate void FormActionHandler(FormActions action, string textToDisplay);
    public event FormActionHandler FormAction;
    private void MyMarshalDataToForm(FormActions action, String textToDisplay)
    {
        try
        {
            object[] args = { action, textToDisplay };
    
            //  The AccessForm routine contains the code that accesses the form.
    
            MarshalDataToForm marshalDataToFormDelegate = FormAction;
    
            //  Execute AccessForm, passing the parameters in args.
    
            if (marshalDataToFormDelegate != null)
            {
                Dispatcher.Invoke(marshalDataToFormDelegate, args);
            }
        }
        catch (Exception ex)
        {
            DisplayException(Name, ex);
            throw;
        }
    }
