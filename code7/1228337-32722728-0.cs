    public class Binding : System.Data.Binding
    {
        public Binding(string path) : base(path)
        {
            NotifyOnValidationError = true;
        }
    }
