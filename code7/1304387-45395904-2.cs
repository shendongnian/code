	/// <summary>
	/// Base class for Controllers that inherit from UIViewController
	/// </summary>
	public class SimpleViewControllerBase : UIViewController
	{
		public SimpleViewControllerBase(IntPtr handle) : base(handle)
        {
		}
        /* This will add "Done" button to numeric keyboard */
		protected void AddDoneButtonToNumericKeyboard(UITextField textField)
		{
			UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, 50.0f, 44.0f));
			var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
			{
				textField.ResignFirstResponder();
			});
			toolbar.Items = new UIBarButtonItem[] {
				new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
				doneButton
			};
			textField.InputAccessoryView = toolbar;
		}
	}
