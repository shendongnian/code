       private bool _isStopVisible;
		public bool IsStopVisible{
			get {
				return _isStopVisible;
			}
			set {
				_isStopVisible= value;
				RaisePropertyChanged ("IsStopVisible");
			}
		}
