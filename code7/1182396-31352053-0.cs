	public class SyncedNullOutput : IWavePlayer
	{
		// where to read data from
		private IWaveProvider _source;
		// time measurement
		Stopwatch _stopwatch = null;
		double _lastTime = 0;
		
		// timer to fire our read method
		System.Timers.Timer _timer = null;
		
		PlaybackState _state = PlaybackState.Stopped;
		public PlaybackState PlaybackState { get { return _state; } }
		
		public SyncedNullOutput(IWaveProvider source)
		{
			_source = source;
		}
		
		public void Dispose()
		{
			Stop();
		}
		
		void _timer_Elapsed(object sender, ElapsedEventArgs args)
		{
			// get total elapsed time, compare to last time
			double elapsed = _stopwatch.Elapsed.TotalSeconds;
			double deltaTime = elapsed - _lastTime;
			_lastTime = elapsed;
			// work out number of samples we need to read...
			int nSamples = (int)(deltaTime * _source.WaveFormat.SampleRate);
			// ...and how many bytes those samples occupy
			int nBytes = nSamples * _source.WaveFormat.BlockAlign;
			
			// Read samples from the source
			byte[] buffer = new byte[nBytes];
			_source.Read(buffer, 0, nBytes);
		}
		
		public void Play()
		{
			if (_state == PlaybackState.Stopped)
			{
				// create timer
				_timer = new System.Timers.Timer(90);
				_timer.AutoReset = true;
				_timer.Elapsed += _timer_Elapsed;
				_timer.Start();
				// create stopwatch
				_stopwatch = Stopwatch.StartNew();
				_lastTime = 0;
			}
			else if (_state == PlaybackState.Paused)
			{
				// reset stopwatch
				_stopwatch.Reset();
				_lastTime = 0;
				// restart timer
				_timer.Start();
			}
			_state = PlaybackState.Playing;
		}
		
		public void Stop()
		{
			if (_timer != null)
			{
				_timer.Stop();
				_timer.Dispose();
				_timer = null;
			}
			if (_stopwatch != null)
			{
				_stopwatch.Stop();
				_stopwatch = null;
			}
			_lastTime = 0;
			_state = PlaybackState.Stopped;
		}
		
		public void Pause()
		{
			_timer.Stop();
			_state = PlaybackState.Paused;
		}
		
		public void Init(IWaveProvider waveProvider)
		{
			Stop();
			_source = waveProvider;
		}
		
		public event EventHandler<StoppedEventArgs> PlaybackStopped;
		
		protected void OnPlaybackStopped(Exception exception = null)
		{
			if (PlaybackStopped != null)
				PlaybackStopped(this, new StoppedEventArgs(exception));
		}
		
		public float Volume {get;set;}
	}
