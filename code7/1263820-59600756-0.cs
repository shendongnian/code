    public class ObservableObject : INotifyPropertyChanged
    {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            protected virtual void OnPropertyChanged<T>(Expression<Func<T>> raiser)
            {
                string propName = ((MemberExpression)raiser?.Body).Member.Name;
                OnPropertyChanged(propName);
            }
    
            protected bool Set<T>(ref T field, T value, [CallerMemberName] string name = null)
            {
                if (!EqualityComparer<T>.Default.Equals(field, value))
                {
                    field = value;
                    OnPropertyChanged(name);
                    return true;
                }
                return false;
            }
    }
