    public class OperationDesc {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string DateString {
            get 
            {
                return Created.ToString();
            }
        }
    }
