    private bool IsCharAllowed(char c)
    {
        var unicodeValue = (int)c;
        if(unicodeValue >= 0 && unicodeValue <= 0x024F) // it's latin
          return true;
        if(unicodeValue >= 0x0590 && unicodeValue <= 0x05FF) // it's hebrew
          return true;
        // otherwise, don't allow it
        return false;
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
          textBox.Text = new string(p.Where(IsCharAllowed).ToArray());         
          _parsingText = false;
        }
    }
