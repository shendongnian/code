    public class MessageDTOEqualityComparer : IEqualityComparer<MessageDTO>
    {
        public bool Equals(MessageDTO a, MessageDTO b)
        {
            // your logic, which checks each messages properties for whatever
            // grounds you need to deem them "equal." In your case, it sounds like
            // this will just be a matter of iterating through each property with an
            // if-not-equal-return-false block, then returning true at the end
        }
    
        public int GetHashCode(MessageDTO message)
        {
            // your logic, I'd probably just return the message ID if you can,
            // assuming that doesn't overlap too much and that it does
            // have to be equal on the two
        }
    }
