    public class ViewModelBase : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _observableprsn = new ObservableCollection<Person>();
        public ObservableCollection<Person> Persons
        {
            get { return _observableprsn; }
            set
            {
                if (_observableprsn != value)
                {
                    _observableprsn = value;
                    RaisePropertyChanged(() => Persons);
                }
            }
        }
        #region implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocatorAttribute]
        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = ExtractPropertyName(propertyExpression);
            this.RaisePropertyChanged(propertyName);
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        private static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException("propertyExpression");
            }
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("The expression is not a member access expression.", "propertyExpression");
            }
            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
            {
                throw new ArgumentException("The member access expression does not access a property.", "propertyExpression");
            }
            var getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic)
            {
                throw new ArgumentException("The referenced property is a static property.", "propertyExpression");
            }
            return memberExpression.Member.Name;
        }
        #endregion
    }
