    public class DelayedProperty<T> : INotifyPropertyChanged
    {
        #region Fields
        private T pendingValue;
        private DispatcherTimer timer;
        private T value;
        #endregion
        #region Properties
        public int Delay { get; set; } = 800;
        public bool IsPendingChanges => this.timer?.IsEnabled == true;
        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (this.Delay > 0)
                {
                    this.pendingValue = value;
                    if (timer == null)
                    {
                        timer = new DispatcherTimer();
                        timer.Interval = TimeSpan.FromMilliseconds(this.Delay);
                        timer.Tick += ValueChangedTimer_Tick;
                    }
                    if (timer.IsEnabled)
                    {
                        timer.Stop();
                    }
                    timer.Start();
                    this.RaisePropertyChanged(nameof(IsPendingChanges));
                }
                else
                {
                    this.SetField(ref this.value, value);
                }
            }
        }
        #endregion
        #region Event Handlers
        private void ValueChangedTimer_Tick(object sender, EventArgs e)
        {
            this.FlushValue();
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Force any pending changes to be written out.
        /// </summary>
        public void FlushValue()
        {
            if (this.IsPendingChanges)
            {
                this.timer.Stop();
                this.SetField(ref this.value, this.pendingValue);
                this.RaisePropertyChanged(nameof(IsPendingChanges));
            }
        }
        /// <summary>
        /// Ignore the delay and immediately set the value.
        /// </summary>
        /// <param name="value">The value to set.</param>
        public void SetImmediateValue(T value)
        {
            this.SetField(ref this.value, value);
        }
        #endregion
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetField<U>(ref U field, U valueField, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<U>.Default.Equals(field, valueField)) { return false; }
            field = valueField;
            this.RaisePropertyChanged(propertyName);
            return true;
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
