	public class ListBoxScrollBehavior : Behavior<ListBox>
	{
		public ListBoxScrollHandler ScrollHandler
		{
			get { return (ListBoxScrollHandler)GetValue(ScrollHandlerProperty); }
			set { SetValue(ScrollHandlerProperty, value); }
		}
		public static readonly DependencyProperty ScrollHandlerProperty =
			DependencyProperty.Register("ScrollHandler", typeof(ListBoxScrollHandler),
			typeof(ListBoxScrollBehavior), new PropertyMetadata(null, OnScrollHandlerChanged));
		
		protected override void OnAttached()
		{
			base.OnAttached();
		}
		protected override void OnDetaching()
		{
			base.OnDetaching();
		}
		private static void OnScrollHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var behavior = d as ListBoxScrollBehavior;
			if (behavior == null)
				return;
			var oldHandler = e.OldValue as ListBoxScrollHandler;
			if (oldHandler != null)
				oldHandler.ScrollEvent -= behavior.ScrollTo;
			
			var newHandler = e.NewValue as ListBoxScrollHandler;
			if (newHandler != null)
				newHandler.ScrollEvent += behavior.ScrollTo;
		}
		public void ScrollTo(object item)
		{
			this.AssociatedObject.ScrollIntoView(item);
		}
		
	}
