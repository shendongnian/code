	public class ListBoxScrollHandler
	{
		public event Action<object> ScrollEvent;
		public void ScrollTo(object item)
		{
			if (this.ScrollEvent != null)
				this.ScrollEvent(item);
		}
	}
