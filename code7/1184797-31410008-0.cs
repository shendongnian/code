    			test.Background = new SolidColorBrush(Colors.MistyRose);
			Clipboard.SetText(test.Text);
			var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
			dispatcherTimer.Tick += new EventHandler((s, x) =>
			{
				dispatcherTimer.Stop();
				test.Background = new SolidColorBrush(Colors.White);
			});
			dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
			dispatcherTimer.Start();
