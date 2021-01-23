    //Creates relationship
	Dictionary<string, string[]> dict = new Dictionary<string, string[]>(){
		{"Clothes", new string[] {"Pants","Shirts"}},
		{"Auto Parts", new string[] {"Tires","Transmissions"}}
	};
	private bool isProcessingSelection = false; //prevents stack overflow
	List<string> listBox1_lastSelections = new List<string>(); //creates memory
	private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {			
		if (isProcessingSelection) //to prevent stack overflow exception because of recursive call
			return;
		
		isProcessingSelection = true; //set true whenever processing
		List<string> currentSelections = listBox1.SelectedItems.Cast<string>().ToList();
		string lastSelection = listBox1_lastSelections.Count > currentSelections.Count ?
			listBox1_lastSelections.Except(currentSelections).FirstOrDefault() :
			currentSelections.Except(listBox1_lastSelections).FirstOrDefault();   
        //get the last selected item by comparison of current and last selection
							
		int index = listBox1.Items.IndexOf(lastSelection); //the last selected index
		
		for (int i = 0; i < listBox1.Items.Count; ++i) {
			if (i == index) //do not process the last selected index
				continue;
			listBox1.SetSelected(i, false); //make everything else false
		}
		if (dict.ContainsKey(lastSelection)) { //if the last selection is among the item in the dictionary, highlight the rests
			string[] related = dict[lastSelection];
			for (int i = 0; i < listBox1.Items.Count; ++i)
				if (related.Contains(listBox1.Items[i].ToString()))
					listBox1.SetSelected(i, true);
		}
		listBox1_lastSelections = listBox1.SelectedItems.Cast<string>().ToList(); //update the last selection
		isProcessingSelection = false; //prepare for the next, non recursive call
	}
