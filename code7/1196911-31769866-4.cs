    public static App Instance { get { return _instance; } }
    
    private Type Resolve(string name)
    {
    	return Type.GetType(string.Format("{0}.Views.{1}Page", this.GetType().Namespace, name));
    }
    
    public void CreateNewNavigationFrame(Frame frame)
    {
    	this.NavigationService = new FrameNavigationService(new FrameFacadeAdapter(frame), Resolve, this.SessionStateService);
    }
