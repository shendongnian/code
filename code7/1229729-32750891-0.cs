	public DecodeTextView(Context c, IAttributeSet args) : base(c, args)
	{
		// ...
		Console.WriteLine ("DecodeTextView executing on thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
	}
	private void _timerAnimate_Tick(object sender, EventArgs e)
	{
		Console.WriteLine ("_timerAnimate_Tick executing on thread: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
		// ...
	}
