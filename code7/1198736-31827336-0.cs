    public class Ok
    {
        public Ok(IList<string> errors, bool success)
        {
            this.Errors = errors;
            this.Success = success;
        }
        public IList<string> Errors { get; set; }
        public bool Success { get; set; }
    }
