    private async void RegexMatchProgressBar(Regex regex, string myText, Microsoft.Office.Interop.Word.Document myDoc)
    {
    	int charCount = myDoc.Application.ActiveDocument.Characters.Count;
    
    	var myProgressAsync = await this.ShowProgressAsync("WAIT WHILE WE DO STUFF!", "Searching...");
    	myProgressAsync.Maximum = charCount;
    	myProgressAsync.Minimum = 0;
    
    	await Task.Run(() => 
    	{
    		Dictionary<String, List<int>> table = new Dictionary<string, List<int>>();
    		foreach (Match match in regex.Matches(myText))
    		{
    			if (!table.ContainsKey(match.Value))
    			{
    				List<int> page = new List<int>();
    				page.Add(42);
    				table.Add(match.Value, page);
    				myProgressAsync.SetProgress((double)match.Index);
    
    			}
    		}
    		
    		myProgressAsync.SetProgress(charCount);
    	});
    	
    	await myProgressAsync.CloseAsync();
    }
