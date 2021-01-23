    public class EditorBinding : Binding
    {
        public EditorBinding()
        {
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            ValidatesOnDataErrors = true;
            NotifyOnValidationError = true;
        }
        public EditorBinding(string path)
            : this()
        {
            Path = new PropertyPath(path);
        }
    }
