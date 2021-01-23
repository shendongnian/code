	public class ExecutionManager
	{
		private readonly int reconfigurationDelay = 50;
		private IObservable<EventArgs> delayedReconfigurations;
		/// <summary>Occurs when a reconfiguration is required.</summary>
		public event EventHandler ReconfigurationRequired;
		/// <summary>Called when a reconfiguration is required.</summary>
		public void OnReconfigurationRequired() => ReconfigurationRequired.Raise(this);
		/// <summary>Initializes the manager.</summary>
		public override void Init()
		{
			base.Init();
			delayedReconfigurations = Observable.FromEvent<EventHandler, EventArgs>(
                h => (s, e) => h(e),
				h => ReconfigurationRequired += h,
                h => ReconfigurationRequired -= h);
			delayedReconfigurations.Throttle(TimeSpan.FromMilliseconds(reconfigurationDelay))
                .Subscribe(e => ReconfigureMeasurement());
		}
		/// <summary>Reconfigures the measurement.</summary>
		public void ReconfigureMeasurement()
		{
			//long/slow method
		}
	}
