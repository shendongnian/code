	public class MyControl : Control
	{
		public event EventHandler NameChanged;
		protected virtual void OnNameChanged()
		{
			EventHandler handler = NameChanged;
			if (handler != null) handler(this, EventArgs.Empty);
			MessageBox.Show("OnNameChanged");
		}
		
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			if (changeService == null) return; // not provided at runtime, only design mode
			changeService.ComponentChanged -= OnComponentChanged; // to avoid multiple subscriptions
			changeService.ComponentChanged += OnComponentChanged;
		}
		private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
		{
			if (e.Component == this && e.Member.Name == "Name")
				OnNameChanged();			
		}
	}
