    public class MouseLeftButtonDownEventTrigger : TriggerBase<UIElement>
	{
		public bool HandledEventsToo { get; set; }
		public bool MarkHandled { get; set; }
		private readonly MouseButtonEventHandler m_buttonDownHandler;
		public MouseLeftButtonDownEventTrigger()
		{
			m_buttonDownHandler = Invoke;
		}
		private void Invoke( object sender, MouseButtonEventArgs eventArgs )
		{
			InvokeActions( null );
			if (MarkHandled) eventArgs.Handled = true;
		}
		protected override void OnAttached()
		{
			base.OnAttached();
			AssociatedObject.AddHandler( UIElement.MouseLeftButtonDownEvent,
                m_buttonDownHandler, HandledEventsToo );
		}
		protected override void OnDetaching()
		{
			AssociatedObject.RemoveHandler( UIElement.MouseLeftButtonDownEvent,
                m_buttonDownHandler );
            base.OnDetaching();
		}
	}
