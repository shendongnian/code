    // needs to be public if the two view models live in different assemblies
    internal class ThePropertyChangedEvent : PubSubEvent<string>
    {
    }
    internal class ViewAViewModel : BindableBase
    {
        public ViewAViewModel( IEventAggregator eventAggregator )
        {
            _eventAggregator = eventAggregator;
            eventAggregator.GetEvent<ThePropertyChangedEvent>().Subscribe( x => TheProperty = x );
        }
        public string TheProperty
        {
            get { return _theProperty; }
            set
            {
                if (value == _theProperty)
                    return;
                _theProperty = value;
                _eventAggregator.GetEvent<ThePropertyChangedEvent>().Publish( _theProperty );
                OnPropertyChanged();
            }
        }
        #region private
        private readonly IEventAggregator _eventAggregator;
        private string _theProperty;
        #endregion
    }
