    public class FileName {
        public string Name { get; set; }
        public List<Error> Errors { get; set; }
        public FileName() 
        {
            Errors = new List<Error>();
        }
    }
