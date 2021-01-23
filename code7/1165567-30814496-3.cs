	public class FooChild : Foo
	{
		protected bool _suppressBarEvent = true;
		
		protected override void OnBar(object sender, EventArgs e)
		{
			if (!_suppressBarEvent)
			{
				base.OnBar(sender, e);
			}
		}
	}
