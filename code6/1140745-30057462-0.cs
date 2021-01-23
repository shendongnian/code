    public class ShipmentVerificationController : ApiController
    {
        //this is the response object you will be sending back to the client website
        public class VerificationResult
        {
            public bool Valid;
        }
        public VerificationResult GetIsItemValid(string BarCode)
        {
            bool itemIsValid;
            // Implement checks against the BarCode string here
            itemIsValid = true;
            return new VerificationResult { Valid = itemIsValid };
        }
    }
