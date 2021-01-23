    public class AddressWrapper : IWrapped<Address>
    {
        private Address _wrapped;
        public Address GetWrapped()
        {
            return _wrapped;
        }
        //And some more
    }
    public class OtherWrapper : IWrapped<MailBox>
    {
        public MailBox GetWrapped()
        {
            throw new MailBox();
        }
    }
