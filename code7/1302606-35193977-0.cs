        private DispatcherTimer _handledTimer;
        private bool _isHandled = false;
        private bool _isShift = false;
        private void txtEmailKeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Shift)
            {
                _isShift = true;
            }
            else
            {
                if (ToChar(e.Key, _isShift))
                {
                    _isHandled = true;
                    StartDispatcher();
                }
                _isShift = false;
            }
            e.Handled = _isHandled;
        }
        public void StartDispatcher()
        {
            if (_handledTimer == null)
            {
                _handledTimer = new DispatcherTimer();
                _handledTimer.Interval = new TimeSpan(0, 0, 1);
                _handledTimer.Tick += handledTimerTick;
            }
            _handledTimer.Stop();
            _handledTimer.Start();
        }
        private void handledTimerTick(object sender, object e)
        {
            _handledTimer.Stop();
            _handledTimer = null;
            _isHandled = false;
        }
        private bool ToChar(VirtualKey key, bool shift)
        {
            bool hasSpecificChar = false;
            // look for %
            if (53 == (int)key && shift)
            {
                hasSpecificChar = true;
            }
            // look for ';'
            if (186 == (int)key)
            {
                hasSpecificChar = true;
            }
            return hasSpecificChar;
        }
