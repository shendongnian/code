    public class Ok
    {
        private Ok(IList<string> errors, bool success)
        {
            this.Errors = errors;
            this.Success = success;
        }
        public IList<string> Errors { get; set; }
        public bool Success { get; set; }
        public static Ok Create(IList<string> errors, bool success)
        {
            return new Ok(errors, success);
        }
    }
