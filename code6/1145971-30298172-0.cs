    public class AgafDescriptor : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _name;
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (_name != value)
				{
					_name = value;
						
					RaisePropertyChanged(x => x.Name);
				}
			}
		}
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged<T>(Expression<Func<AgafDescriptor, T>> propertyExpression)
        {
            PropertyChangedEventHandler localPropertyChanged = this.PropertyChanged as PropertyChangedEventHandler;
            if ((localPropertyChanged != null) && (propertyExpression != null))
            {
                MemberExpression body = propertyExpression.Body as MemberExpression;
                if (body != null)
                {
                    localPropertyChanged(this, new PropertyChangedEventArgs(body.Member.Name));
                }
            }
        }
        #endregion
        #region IDataErrorInfo Members
        // Does nothing in WPF.
        public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {
                string returnVal = null;
                if (string.Equals("Name", columnName, StringComparison.Ordinal))
                {
                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        returnVal = "A name must be supplied.";
                    }
                }
                return returnVal;
            }
        }
        #endregion
    }
