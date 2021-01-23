    public static class ProperyChangedEventExtensions
    {
        public static void RaisePropertyChanged<T, P>(this T sender, Expression<Func<T, P>> propertyExpression) where T : INotifyPropertyChanged
        {
            Raise(typeof(T), sender, (propertyExpression.Body as MemberExpression).Member.Name);
        }
        public static void RaisePropertyChanged(this INotifyPropertyChanged sender, [CallerMemberName] string prop = null)
        {
            Raise(sender.GetType(), sender, prop);
        }
        private static void Raise(Type targetType, INotifyPropertyChanged sender, string propName)
        {
            var evtPropType = targetType.GetField("PropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
            var evtPropVal = (PropertyChangedEventHandler)evtPropType.GetValue(sender);
            evtPropVal(sender, new PropertyChangedEventArgs(propName));
        }
    }
