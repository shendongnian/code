     public BusinessException : Exception
     {
         public BusinessException(string reason)
         {
               Reason  = reason;
         }
         public string Reason {get; set;}
     }
