    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                throw new Exception("'Gender' element is invalid");
            }
            catch (Exception ex)
            {
                Error err = Error.ReadError(ex);
            }
        }
    }
    
    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorRaw { get; set; }
        public static List<Error> ErrorList { get; private set; }
    
        static Error()
        {
            ErrorList = new List<Error>()
            {
                new Error(){
                    ErrorCode = "EC005",
                    ErrorMessage = "TierType is incorrect",  
                    ErrorRaw = "'TierType' element is invalid"
                },
                new Error(){
                    ErrorCode = "EC010",
                    ErrorMessage = "Gender is incorrect",  
                    ErrorRaw = "'Gender' element is invalid"
                },
                
            };
        }
    
        public static Error DefaultError(Exception ex)
        {
            return new Error(){
                    ErrorCode = "EC050",
                    ErrorMessage = ex.Message
                };
        }
    
        public static Error ReadError(Exception ex)
        {
            Error error = ErrorList.FirstOrDefault(e => ex.Message.Contains(e.ErrorRaw));
            if (error == null)
            {
                error = Error.DefaultError(ex);
            }
    
            return error;
        }
    }
