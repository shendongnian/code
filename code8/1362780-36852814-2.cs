    public partial class ViewController : UIObserveTitleChangedViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
            this.TitleChanged += ViewController_TitleChanged; // Subscribe to TitleChanged
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = "Some title";            // triggers TitleChanged
            Title = "Another new title";     // triggers TitleChanged
        }
        private void ViewController_TitleChanged(object sender, TitleChangedEventArgs args)
        {
            Debug.WriteLine("Title changed from {0} to {1}", args.OldTitle, args.NewTitle);
        }
    }
