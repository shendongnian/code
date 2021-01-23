    public static App Instance { get { return _instance; } }
    
    private Type Resolve(string name)
    {
    	return typeof(Views.GroupPage); //TODO: add a real impl.
    }
    
    public void CreateNewNavigationFrame(Frame frame)
    {
    	NavService = this.NavigationService = new FrameNavigationService(new FrameFacadeAdapter(frame), Resolve, this.SessionStateService);
    }
