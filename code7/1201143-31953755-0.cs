	public delegate void ValidationDelegate(bool isValid);
	public class MyViewModel : ViewModelBase
	{
		public ValidationDelegate ValidationHandler { get { return (isValid) => OnValidate(isValid); } }
		private void OnValidate(bool isValid)
		{
			// handle the validation event here
		}
	}
