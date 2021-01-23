    /// <summary>
    /// When text changes keywords are searched for and highlighted
    /// </summary>
    /// <param name="e"></param>
    protected override void OnTextChanged(EventArgs e)
    {
        if (highlighting)
            return;
    
        int currentSelectionStart = this.SelectionStart;
        int currentSelectionLength = this.SelectionLength;
    
        base.OnTextChanged(e);
    
        String text = this.Text;
        base.Text = "";
    
        this.HighlightSyntax(text);
    
        this.SelectionStart = currentSelectionStart;
        this.SelectionLength = currentSelectionLength;
    }
