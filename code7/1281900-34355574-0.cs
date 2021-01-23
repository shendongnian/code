    private void DoValidations(Delegate addErrorMessage)
    {
        if (!this.IsDisabled)
        {
            this.OnDoValidations(addErrorMessage);
        }
    }
    virtual void OnDoValidations(Delegate addErrorMessage) { }
