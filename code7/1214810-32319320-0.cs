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
	public class Form1
	{
		private btnBack_Click(object sender, EventArgs e)
		{
			if (this.Tabs.SelectedIndex == 0)
            {
				Program.IsComplete = false;
                Close();
            }
		}
		// something somewhere should set Program.IsComplete = true
	}
