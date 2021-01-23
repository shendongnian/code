     /// <summary>
        /// wrapper to keep from exposing the actual event. Want to force them to subscribe weakly
        /// </summary>
        private OnIntensityChangedEventWrapper onIntensityChangedEventWrapper = new ADAHelper.OnIntensityChangedEventWrapper();
        /// <summary>
        /// Event notifying when the intensity has changed. This event will only fire when the ADA button was pressed.
        /// </summary>
        public static void Subscribe_OnIntensityChanged(EventHandler<IntensityChangedEventArgs> eventHandler)
        {
            WeakEventManager<OnIntensityChangedEventWrapper, IntensityChangedEventArgs>.AddHandler(Instance.onIntensityChangedEventWrapper, nameof(OnIntensityChangedEventWrapper.OnIntensityChanged), eventHandler);
        }
        private class OnIntensityChangedEventWrapper
        {
            public event EventHandler<IntensityChangedEventArgs> OnIntensityChanged;
            public void Fire(Intensity intensity)
            {
                if (OnIntensityChanged != null)
                {
                    OnIntensityChanged(this, new IntensityChangedEventArgs(intensity));
                }
            }
        }
