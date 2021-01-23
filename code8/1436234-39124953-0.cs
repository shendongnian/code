    public class PropertyChangedHandler : Dictionary<string, Action>
    {
        public PropertyChangedHandler(INotifyPropertyChanged source)
        {
            source.PropertyChanged += Source_PropertyChanged;
        }
        private void Source_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Action toDo;
            if (TryGetValue(e.PropertyName, out toDo))
            {
                toDo();
            }
        }
    }
