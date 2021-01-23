	static class Program
	{
		static void Main()
		{
			do
			{
				var formA = new FormA();
				Application.Run(formA);
				var formB = new FormB(formA.SelectedConfigurationFile);
				Application.Run(formB);
			} while (!IsComplete);
		}
		public static IsComplete { get; set;}
	}
	public class FormB
	{
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (e.CloseReason == CloseReason.UserClosing)
                Program.IsComplete = true;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.IsComplete = true;
            Close();
        }
		private void btnBack_Click(object sender, EventArgs e)
		{
			if (this.Tabs.SelectedIndex == 0)
            {
				Program.IsComplete = false;
                Close();
            }
		}
	}
