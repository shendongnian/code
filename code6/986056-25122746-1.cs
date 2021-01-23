      int restrictCount = <your restriction length> //Enter your number of character restriction
      Entry entry = new Entry();
      entry.TextChanged += OnTextChanged;
      void OnTextChanged(object sender, EventArgs e)
	  {
        Entry e = sender as Entry;
		String val = e.Text; //Get Current Text
          
        if(val.Length > restrictCount)//If it is more than your character restriction
        {
         val = val.Remove(val.Length - 1);// Remove Last character 
         e.Text = val; //Set the Old value
        }
      }
