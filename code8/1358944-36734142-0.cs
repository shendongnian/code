    //New list to store pressed chars
    List<char> usedChars = new List<char>();
    
    public void FindString (char Somechar)
    {
    	 //New StringBuilder to build final string
    	 StringBuilder sbWordIs = new StringBuilder();
    	 
         int i = textBox1.TextLength;
         for (int j = 0; j < i; j++)
         {
            if (Somechar == textBox1.Text[j])
            {
    			//Store new correct char
                if (!usedChars.Contains(Somechar)) usedChars.Add (Somechar);
            }
    		
            //Check whether each char in word was already pressed or not
    		if (usedChars.Contains(textBox1.Text[j])) sbWordIs.Append(textBox1.Text[j]);
    		else sbWordIs.Append ("_"); //If not, show an underscore
        }
    	
    	//Say yor new textbox is named "textBox2"
    	textBox2.Text = sbWordIs.ToString();
    }
