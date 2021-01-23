    public partial class CameraViewController : UIViewController
	{
		static UIImagePickerController picker;
		static UIImageView staticImageView;
		public CameraViewController() : base("CameraViewController", null)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			base.Title = "Kamera";
			staticImageView = this.imageView;
		}
 		partial void openCamera(UIButton sender)
		{
			if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
			{
				picker = new UIImagePickerController();
				picker.Delegate = new CameraDelegate();
				picker.SourceType = UIImagePickerControllerSourceType.Camera;
				NavigationController.PresentViewController(picker, true, null);
			}
			else
			{
				this.button.Hidden = true;
			}
		}
		class CameraDelegate : UIImagePickerControllerDelegate
		{
			public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
			{
				picker.DismissModalViewController(true);
				var image = info.ValueForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;
				CameraViewController.staticImageView.Image = image;
			}
		}
	}
