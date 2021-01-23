    public SomeViewController(UIColor color, CGRect frame) : base("SomeViewController", null)
    {
         this.color = color;
         this.frame = frame;
    }
    
    public override void ViewDidLoad()
    {
         base.ViewDidLoad();
    
         this.View.BackgroundColor = color;
         this.View.Frame = frame;
    }
