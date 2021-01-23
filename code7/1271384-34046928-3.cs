    public void mySave(IRibbonControl control, bool cancelDefault)
    {
        If (repurposing)
        {
            MessageBox.Show("The Save button has been temporarily repurposed.");
            cancelDefault = False;
        }
        else
        {
            cancelDefault = False;
        }
    }
