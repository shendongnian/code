	internal class Controller : INotifyPropertyChanged
	{
		private bool button1Enabled;
		public bool Button1Enabled
		{
			get { return this.button1Enabled; }
			set
			{
				if (this.button1Enabled == value) return;
				this.button1Enabled = value;
				this.NotifyChange("Button1Enabled");
			}
		}
	}
