    public class MainAppForm : Form
    {
		static MainAppForm mainAppForm;
		
		public MainAppForm()
		{
			mainAppForm = this;
		}
		
		public static void NotifyOk(Form sender, string fullMessage = "Ok.", string shortMessage = null)
		{
			mainAppForm.NotifyOk(sender, fullMessage, shortMessage);
		}
		
		public void NotifyOk(Form sender, string fullMessage, string shortMessage)
		{
			this.statusStrip.Invoke(delegate {
				this.statusStrip.Text = shortMessage;
			});
		}
    }
