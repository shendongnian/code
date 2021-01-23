    [MessageContract(IsWrapped = false)]
        public class YourClass
        {
            [MessageHeader]
            public string HeaderName;
            
            [MessageBodyMember(Order = 1)]
            public string BodyVariable;
        }
