	private void OnTimerTickElapsed(Object sender, EventArgs e)
	        {
	            var task = Task.Factory.StartNew(async () =>
	            {
	                float usage = await _CPUCounter.NextValue();           
	                RadialGauge r_gauge = (RadialGauge)this.ultraGauge.Gauges[0];                   
	                r_gauge.Scales[0].Markers[0].Value = usage;
	            }, TaskCreationOptions.LongRunning);
	        }
