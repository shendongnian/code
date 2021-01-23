    public class MyControl : UserControl
    {
        // ... the code so far
        // override OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			myGroupBox.Text = Name; // or WhenNameChanged(this, EventArgs.Empty);
		}
    }
