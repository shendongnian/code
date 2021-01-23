    public class VideoViewModel : PropertyChangedBase, IDeactivate
    {
        private bool _isClosing;
        public bool IsClosing
        {
            get { return _isClosing; }
            set
            {
                _isClosing = value;
                NotifyOfPropertyChange(() => IsClosing);
            }
        }
    
        public void Deactivate(bool close)
        {
            IsClosing = close;
        }
    
        public event EventHandler<DeactivationEventArgs> AttemptingDeactivation;
        public event EventHandler<DeactivationEventArgs> Deactivated;
    }
