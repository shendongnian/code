    public ActionResult DoSomething()
    {
        using (GYOSContext context = new GYOSContext())
        {
            // Do stuff with context
    
        }  // Automatically disposed when exiting scope of using block
    }
