    public string Name { get; set;}
    public void methodThatYouSetData()
    {
        Name=txtbx.Text;
        this.DialogResult=DialogResult.OK;  
    }
