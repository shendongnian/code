    // Set which characters you allow here
    private bool IsCharAllowed(char c)
    {
        return (c >= 'a' && c <= 'z')
    }    
    private bool _parsingText = false;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // if we changed the text from within this event, don't do anything
        if(_parsingText) return;
    
        var textBox = sender as TextBox;
        if(textBox == null) return;
    
        // if the string contains any not allowed characters
        if(textBox.Text.Any(x => !IsCharAllowed(x))
        {        
          // make sure we don't reenter this when changing the textbox's text
          _parsingText = true;
          // create a new string with only the allowed chars
          textBox.Text = new string(textBox.Text.Where(IsCharAllowed).ToArray());         
          _parsingText = false;
        }
    }
