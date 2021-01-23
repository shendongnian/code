	public class Foo
	{
		public event EventHandler Bar;
		
		protected virtual void OnBar(object sender, EventArgs e)
		{
			var bar = this.Bar;
			if (bar != null)
			{
				bar(sender, e);
			}
		}
	}
