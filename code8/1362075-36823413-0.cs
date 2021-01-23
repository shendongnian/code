    public class ApiResponseDTO<T> {
     
        [DataMember]
        public string Version { get { return "1.2.3"; } }
    
        [DataMember]
        public double StatusCode { get; set; }
    
        [DataMember]
        public List<string> ErrorMessages { get; set; }
    
        [DataMember]
        public T Result { get; set; }
    
        public ApiResponseDTO()
        {
            ErrorMessages = new List<string>();
        }
    
        public ApiResponseDTO(T value, double statusCode)
        {
            StatusCode = (int)statusCode;
            Result = value;
            ErrorMessages = new List<string>();
        }
    }
