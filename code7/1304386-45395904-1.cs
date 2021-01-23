    public partial class ViewController : SimpleViewControllerBase
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AddDoneButtonToNumericKeyboard("NumericTextFieldName");
		}
    }
