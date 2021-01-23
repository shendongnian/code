    private void syntaxWorker_DoWork(object sender, DoWorkEventArgs e)
    {
    	if (e.Argument == null)
    		Thread.Sleep(100);
    	else
    	{
    		Dictionary<TextBlock, String> dic = (Dictionary<TextBlock, String>)e.Argument;
    
    		foreach (KeyValuePair<TextBlock, String> kvp in dic)
    		{
    			//i am unsure if this line will work. if it does not, you might need to do a separate dispatcher invoke in order to retreive the text from the textbox.
    			List<Run> runs = Syntax.Highlight(kvp.Value); 
    			kvp.Key.Dispatcher.BeginInvoke(new Action(() =>
    			{
    				kvp.Key.Inlines.Clear();
    				runs.ForEach(x => kvp.Key.Inlines.Add(x));
    			}));
    		}
    	}
    }
