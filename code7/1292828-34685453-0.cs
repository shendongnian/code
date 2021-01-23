    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(ExtractPropertyName(propertyExpression)));
        }
        private static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");
            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("memberExpression");
            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("property");
            var getMethod = property.GetGetMethod(true);
            if (getMethod.IsStatic)
                throw new ArgumentException("static method");
            return memberExpression.Member.Name;
        }
    }
