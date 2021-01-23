	public class Responder
	{
		public Responder(Form1 form)
		{
			form.ButtonClicked += OnButtonClicked;
		}
		private void OnButtonClicked(object sender, EventArgs args)
		{
			MessageBox.Show("Button was clicked");
		}
	}
