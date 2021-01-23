        public MainPage() {
            this.InitializeComponent();
			Window.Current.CoreWindow.KeyDown += Canvas_KeyDown;
        }
		private void Canvas_KeyDown(object sender, KeyEventArgs e) {
			var actual = scrollViewer.ZoomFactor;
			if (e.VirtualKey == Windows.System.VirtualKey.Add)
				scrollViewer.ChangeView(null, null, actual + 0.2f);
			else if (e.VirtualKey == Windows.System.VirtualKey.Subtract)
				scrollViewer.ChangeView(null, null, actual - 0.2f);
		}
