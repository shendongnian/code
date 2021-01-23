    private delegate void SetTextCallback2(string text);
    
    private void SetText2(string text)
    {
    	try {
    		if (this.RichTextBox1.InvokeRequired) {
    			SetTextCallback2 d = new SetTextCallback2(SetText2);
    			this.Invoke(d, new object[] { text });
    
    		} else {
    			this.RichTextBox1.Text = text;
    			result = text.Split(stringSeparators);
    			TextBox1.Text = result.ElementAt(4);
    			TextBox2.Text = result.ElementAt(8);
    			TextBox3.Text = result.ElementAt(12);
    
    		}
    
    
    	} catch (Exception ex) {
    	}
    
    }
