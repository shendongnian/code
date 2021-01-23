		Dictionary<string, Delegate> _callbacks = new Dictionary<string, Delegate>();
		public MainWindow()
		{
			InitializeComponent();
			_callbacks.Add("move", new Action<Point, Point>(Move));
			_callbacks.Add("remove", new Action(Remove));
			Application.Current.Dispatcher.BeginInvoke(_callbacks["move"], new Point(5, 6), new Point(1, 3));
			Application.Current.Dispatcher.BeginInvoke(_callbacks["remove"]);
		}
		public void Move(Point something1, Point something2)
		{
		}
		public void Remove()
		{
		}
