    public partial class ProfileController : UIViewController
    {
		
        public ProfileController (IntPtr handle) : base (handle)
        {
			Id = -99;
        }
		public int Id { get; set; }
		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
			if (segueIdentifier == "StackOverflow")
				return true;
			return base.ShouldPerformSegue(segueIdentifier, sender);
		}
		[Export("prepareForSegue:sender:")]
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			Console.WriteLine("ProfileController.PrepareForSegue()");
			Console.WriteLine($"  - ID = {Id}");
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Console.WriteLine("ProfileController.ViewDidLoad()");
			Console.WriteLine($"  - ID = {Id}");
		}
		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			Console.WriteLine("ProfileController.ViewWillAppear()");
			Console.WriteLine($"  - ID = {Id}");
		}
	}
