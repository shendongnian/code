    Handler CloseButtonClicked;
    public void OnCloseButtonClicked(EventArgs e)
    {
        var handler = CloseButtonClicked;
        if (handler != null)
            handler(this, e);
    }
    private void CloseButton_Click(object sender, EventArgs e)
    {
        //Whilst you can call `this.ParentForm.Close()` it's better to raise an event
        OnCloseButtonClicked(e);
    }
