	public class SamplePage : ContentPage
	{
		public SamplePage ()
		{
			var editText = new Entry {
				Placeholder = "Select Date.",
			};
			var date = new DatePicker {
				IsVisible = false,
				IsEnabled = false,
			};
			var stack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Children = {editText, date}
			};
			editText.Focused += (sender, e) => {
				date.Focus();
			};
			date.DateSelected += (sender, e) => {
				editText.Text = date.Date.ToString();
			};
			Content = stack;
		}
	}
