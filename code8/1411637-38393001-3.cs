    private class ThrottleCalculator
    {
        private readonly int _throttle;
        private DateTime _lastCalculationTime;
        private double _measured = 0;
        private double _totalError = 0;
        private double _integral = 0;
        private double _lastError = 0;
    
        public ThrottleCalculator(int throttle)
        {
            this._throttle = throttle;
            this._lastCalculationTime = DateTime.MinValue;
        }
    
        public async Task CalculateThrottle()
        {
            var kp = -.1d;      // proportional gain
            var ki = -.1d;      // integral gain
            var kd = -.1d;      // derivative gain
            var dt = 30d;       // rate of change of time. calculcations every ms;
    
            this._measured += 1;
            if (this._lastCalculationTime == DateTime.MinValue)
                this._lastCalculationTime = DateTime.Now;
            var elapsed = (double)DateTime.Now.Subtract(this._lastCalculationTime)
                         .TotalMilliseconds;
            if (elapsed > dt)
            {
                this._lastCalculationTime = DateTime.Now;
                var error = ((double)this._throttle / (1000d / dt)) - this._measured;
                this._totalError += error;
                var integral = this._totalError;
                var derivative = (error - this._lastError) / elapsed;
                var actual = (kp * error) + (ki * integral) + (kd * derivative);
                var output = actual;
                if (output < 1)
                    output = 0;
                // i don't like this, but it seems necessary
                // so that wild wait values are never used.
                if (output > dt * 4)
                    output = dt * 4;
                if (output > 0)
                    await Task.Delay((int)output);
                this._measured = 0;
                this._lastError = error;
            }
        }
    }
