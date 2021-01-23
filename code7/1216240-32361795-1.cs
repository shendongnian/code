    // clear the form
    tabUSB_Prep.Controls.Clear();
 
    // This is just to show crossing a "context" works
    string test = "";
    // get the UI's current TaskScheduler
    var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
  
    // This can be used to wrap a method that doesn't 
    // directly implement async/await  
    Task.Run(() =>
    {  
        // Your method to GET the data (don't update the UI here)
        test = "I can set a variable in this context!";
    
    }).ContinueWith(task =>
    {
    	if (task.Status == TaskStatus.RanToCompletion)
    	{
            // update your UI here
            // Again, this is just to show how crossing the context works
            MessageBox.Show(test);
    	}
    	else
    	{
            // update UI with an error message, or display a MessageBox?
    	}
    }, scheduler);
