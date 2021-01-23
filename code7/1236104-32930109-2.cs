    namespace WpfCommands
    {
        public class DataModel
        {
            public void Validate(Validator v)
            {
                // do some validation
                v.Errors.Add(new Error() { Message = "Error1" });
            }
        }
    
        // aggregator for validation errors
        public class Validator
        {
            IList<Error> _errors = new List<Error>();
    
            public IList<Error> Errors { get { return _errors; } }
        }
    
        public class Error
        {
            public string Message { get; set; }
        }
    }
