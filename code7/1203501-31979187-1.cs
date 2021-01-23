	var observables = new []
	{
		Observable.FromEventPattern
			<System.Timers.ElapsedEventHandler, System.Timers.ElapsedEventArgs>
			(h => timers[0].Elapsed += h, h => timers[0].Elapsed -= h),
		Observable.FromEventPattern
			<System.Timers.ElapsedEventHandler, System.Timers.ElapsedEventArgs>
			(h => timers[1].Elapsed += h, h => timers[1].Elapsed -= h),
	};
