        public bool IsAutomated
        {
            get { return _isAutomated; }
            set
            {
                _isAutomated = value;
                _isAutomateds.OnNext(value);
                if (_isAutomated)
                {
                    this.Trigger();
                }
            }
        }
