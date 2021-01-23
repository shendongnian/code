     public class PolicyAddressChangedEvent : IDomainEvent
        {
            public Address NewAddress { get;  }
            public Address OriginalAddress { get;  }
    
            public PolicyAddressChangedEvent(Address oldBillingAddress, Address newbillingAddress)
            {
                OriginalAddress = oldBillingAddress;
                NewAddress = newbillingAddress;
            }
        }
