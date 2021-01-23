        public void Trigger()
        {
            if (_isAutomated)
            {
                _serialSubscription.Disposable =
                    Observable
                        .Interval(_automatedPeriod)
                        .StartWith(0)
                        .TakeUntil(_isAutomateds.Where(x => x == false))
                        .Subscribe(n => _messages.OnNext(_message));
            }
            else
            {
                _messages.OnNext(_message);
            }
        }
