    internal class SampleClass : INotifyPropertyChanged{
        public event PropertyChangedEventHandler PropertyChanged;
        private string _SampleProperty;
        internal List<string> _ChangedProperties;
        public SampleClass() {
          this.PropertyChanged += SampleClass_PropertyChanged;
          _ChangedProperties = new List<string>();
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
            if ( PropertyChanged != null )
              PropertyChanged( this, new PropertyChangedEventArgs( "SampleProperty" ) );
          }
    }
