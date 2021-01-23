    [assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
	public class CustomEntryRenderer :  EntryRenderer
	{
		public CustomEntryRenderer()
		{
    		HideKeyboard();
		}
		void HideKeyboard()
		{
			this.Control.InputType = 0;
			InputMethodManager inputMethodManager = this.Control.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
			inputMethodManager.HideSoftInputFromWindow(this.Control.WindowToken, HideSoftInputFlags.ImplicitOnly);
		}
		// ...
	}
