        class Details
        {
            public string Country { get; set; }
        }
        class Client
        {
            private Details _details;
            public string Country
            {
                get
                {
                    return _details == null ? string.Empty : _details.Country;
                }
            }
            public Details GetDetails()
            {
                return _details;
            }
        }
