    string filter = sometextbox.Text;
    Regex rgx = new Regex(filter);
    bool IsRegEx = RegExCheckBox.Checked;
    
    List<string> Matches = new List<string>();
    
    for (int i = 0; i < data.Count; i++)
    {
    	if (IsRegEx && rgx.IsMatch(data[i].Content))
        	Matches.Add(data[i].Content);
    	else if (!IsRegEx && data[i].Content.ToLower().Contains(filter.ToLower())) 
    		Matches.Add(data[i].Content);
    }
    //Do something with your list of Matches
