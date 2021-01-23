      int restrictCount = <your restriction length> //Enter your number of character restriction
      Entry entry = new Entry();
      entry.TextChanged += OnTextChanged;
      void OnTextChanged(object sender, EventArgs e)
	  {
        Entry entry = sender as Entry;
		String val = entry.Text; //Get Current Text
          
        if(val.Length > restrictCount)//If it is more than your character restriction
        {
         val = val.Remove(val.Length - 1);// Remove Last character 
         entry.Text = val; //Set the Old value
        }
      }
