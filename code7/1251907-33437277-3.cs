    public class EditorBinding : Binding
    {
        public EditorBinding()
        {
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            ValidatesOnDataErrors = true;
            NotifyOnValidationError = true;
        }
        public EditorBinding(PropertyPath path)
            : this()
        {
            Path = path;
        }
    }
