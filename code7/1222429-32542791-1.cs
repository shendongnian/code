    [Serializable]
    class CustomException : FormatException
    {
        /// <summary>
        /// Just create the exception
        /// </summary>
        public CustomException()
        : base() {
        }
     
        /// <summary>
        /// Create the exception with description
        /// </summary>
        /// <param name="message">Exception description</param>
        public CustomException(String message)
        : base(message) {
        }
    
        /// <summary>
        /// Create the exception with description and inner cause
        /// </summary>
        /// <param name="message">Exception description</param>
        /// <param name="innerException">Exception inner cause</param>
        public CustomException(String message, Exception ex)
        : base(message, ex) {
        }
    }
