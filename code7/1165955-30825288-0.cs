    public string Text
    {
        get { return this.SomeTextBoxOnTheForm.Text; }
        set { this.SomeTextBoxOnTheForm.Text = value; }
    }
    //called from your "Save" button.
    public void Save()
    {
        this.DialogResult = DialogResult.Ok;
        this.Close();
    }
    //called from either your "DontSave" button or your "Cancel" button.
    public void Cancel()
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
