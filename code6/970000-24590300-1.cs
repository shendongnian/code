    internal class SampleClass : INotifyPropertyChanged{
        public event PropertyChangedEventHandler PropertyChanged;
        private string _SampleProperty;
        internal List<string> _ChangedProperties;
        public SampleClass() {
          this.PropertyChanged += SampleClass_PropertyChanged;
          _ChangedProperties = new List<string>();
        }
        protected virtual void OnPropertyChanged( string propertyName ) {
              PropertyChangedEventHandler handler = PropertyChanged;
              if ( handler != null )
                handler( this, new PropertyChangedEventArgs( propertyName ) );
        }
        void SampleClass_PropertyChanged( object sender, PropertyChangedEventArgs e ) {
          if ( _ChangedProperties.Contains( e.PropertyName ) ) return;
          _ChangedProperties.Add( e.PropertyName );
        }
        public string SampleProperty {
          get { return _SampleProperty; }
          set {
            if (_SampleProperty == value )
              return;
            _SampleProperty = value;
            OnPropertyChanged( "SampleProperty" );
          }
        }
    }
