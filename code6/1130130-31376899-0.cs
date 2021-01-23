    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            // Initial default values:
            Data = default(T);
            Succeeded = true;
            StatusMessage = string.Empty;
        }
        // Indicates whether the attempted operation was completed successfully. 
        [DataMember]
        public bool Succeeded { get; set; }
        // Error messages if an operation fails.
        [DataMember]
        public string StatusMessage { get; set; }
        // The main results from any service-call.        
        [DataMember]
        public T Data { get; set; }
        [DataMember]
        public String InnerExceptionMessage { get; set; }
		
		public static ServiceResponse<T> CreateServiceResponse(Func<T> responseFunc)
        {
            var response = new ServiceResponse<T>();
            try
            {
                response.Data = responseFunc.Invoke();
            }
            catch (Exception ex)
            {
                response = HandleException(responseFunc, ex);
            }
            return response;
        }
		
		private static ServiceResponse<T> HandleException(Func<T> responseFunc, Exception ex)
        {
			// Handle any exceptions here, and return a ServiceResponse with 
			// Succeeded = false, and the appropriate messages, etc.
		}
	}
	
	
