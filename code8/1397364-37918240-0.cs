    public void OnPageScrollStateChanged(int state)
    {
    	Console.WriteLine("Page scroll state changed: " + state);
    }
    
    public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
    {
    	Console.WriteLine("Page Scrolled");
    }
    
    public void OnPageSelected(int position)
    {
    	// Here get the new data and reloadData from list
    }
