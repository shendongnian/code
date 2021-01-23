    private void BtnTest_Click(object sender, EventArgs e)
    {
        ErrorHandling EH = new ErrorHandling();
        EH.updatetbtest(this);
    }
    public void updatetbtest(Form_DMM form)
    {
        string FailedMessagePB = "Test Message" + "\n";
        form.TextBoxAppend(FailedMessagePB);
    }
