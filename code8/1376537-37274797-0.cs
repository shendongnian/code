    public class EntityValidator
    {
        public void Validate(IEnumerable<int> validEntityIds, RequestA request)
        {
            var invalidRequestIds = request.RequestedDataIds.Where(requestedId => !validEntityIds.Contains(requestedId));
            if (invalidRequestIds.Any())
            {
                throw new SomeException("Error");
            }
        }
    }
 
