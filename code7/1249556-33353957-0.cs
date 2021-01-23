    public class StrippedResponse
    {
        public int ID { get; set; }
        ...
        public override bool Equals(object obj)
        {
            return ID == ((StrippedResponse)obj).ID;
        }
    }
   
  
    ConcurrentQueue<StrippedResponse> responses = new  ConcurrentQueue<StrippedResponse>();
    public void YourMethod()
    {
        // Add elements to the responses object.
        if (responses.Any(e => e.Equals(request)))
        {
          // Do something special
        }
    }
