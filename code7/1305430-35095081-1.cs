    /// <summary>
    /// A static class that manages the Shaken event for the Accelerometer class
    /// </summary>
    public static class CustomAccelerometer
    {
        // The minimum acceleration value to trigger the Shaken event
        private const double AccelerationThreshold = 2;
        // The minimum interval in milliseconds between two consecutive calls for the Shaken event
        private const int ShakenInterval = 500;
        private static bool _AccelerometerLoaded;
        private static Accelerometer _DefaultAccelerometer;
        /// <summary>
        /// Gets the current Accelerometer in use
        /// </summary>
        private static Accelerometer DefaultAccelerometer
        {
            get
            {
                if (!_AccelerometerLoaded)
                {
                    _AccelerometerLoaded = true;
                    _DefaultAccelerometer = Accelerometer.GetDefault();
                }
                return _DefaultAccelerometer;
            }
        }
        private static DateTime _ShakenTimespan = DateTime.Now;
        private static bool _Enabled;
        /// <summary>
        /// Gets or sets whether or not the Accelerometer is currently enabled and can raise the Shaken event
        /// </summary>
        public static bool Enabled
        {
            get { return _Enabled; }
            set
            {
                if (_Enabled != value && DefaultAccelerometer != null)
                {
                    if (value) DefaultAccelerometer.ReadingChanged += _DefaultAccelerometer_ReadingChanged;
                    else DefaultAccelerometer.ReadingChanged -= _DefaultAccelerometer_ReadingChanged;
                }
                _Enabled = value;
            }
        }
        // Handles the ReadingChanged event and raises the Shaken event when necessary
        private static void _DefaultAccelerometer_ReadingChanged(Accelerometer sender, AccelerometerReadingChangedEventArgs args)
        {
            double g = Math.Round(args.Reading.AccelerationX.Square() + args.Reading.AccelerationY.Square() + args.Reading.AccelerationZ.Square());
            if (g > AccelerationThreshold && DateTime.Now.Subtract(_ShakenTimespan).Milliseconds > ShakenInterval)
            {
                _ShakenTimespan = DateTime.Now;
                Shaken?.Invoke(null, EventArgs.Empty);
            }
        }
        /// <summary>
        /// Raised whenever the Accelerometer detects a shaking gesture
        /// </summary>
        public static event EventHandler Shaken;
    }
