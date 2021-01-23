    // basic base class for your models, you a
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator] // remove if you are not using R#
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    // your model
    public class Model : ModelBase
    {
        private string modelName;
        private Template template;
        public string ModelName
        {
            get { return modelName; }
            set
            {
                if (value == modelName) return;
                modelName = value;
                OnPropertyChanged();
            }
        }
        public virtual Template Template
        {
            get { return template; }
            set
            {
                if (Equals(value, template)) return;
                template = value;
                OnPropertyChanged();
            }
        }
    }
