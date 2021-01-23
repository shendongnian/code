        private DispatcherTimer _Timer = new DispatcherTimer();
		private bool _CanExecute;
		
		private void StartTimer()
		{
			var mytime = new DateTime( DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0 );
			
			var interval = DateTime.UtcNow - mytime - TimeSpan.FromMinutes( 4 );
			_Timer.Interval = interval;
			_Timer.Tick += Timer_Tick;
		}
		
		private void Timer_Tick( object sender, EventArgs e )
		{
			_Timer.Tick -= Timer_Tick;
			_CanExecute = true;
			CommandManager.InvalidateRequerySuggested();
		}
		public ICommand Open
		{
			get { return new RelayCommand( ExecuteOpen, () => _CanExecute ); }
		}</code></pre>
