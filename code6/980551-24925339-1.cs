    public ActionResult PostData(string text)
    {
    	//1. Save post to database
    	var databaseTask = Task.Factory.StartNew(this.SavePostToDatabase);
    
    	//2. Send email async
    	databaseTask.ContinueWith(task => this.SendEmail());
    
    	//3. Confirmation view
    	return RedirectToAction("PostConfirmed");
    }
    
    protected void SendEmail()
    {
    	throw new NotImplementedException();
    }
    
    private void SavePostToDatabase()
    {
    	throw new NotImplementedException();
    }
