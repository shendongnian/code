    class Address
    {
        public string Street {get;set;}
        public string Zip {get;set;}
        public Address Copy()
        {
            var result = new Address();
            result.Street = this.Street;
            retult.Zip = this.Zip;
            return result;
        }
    }
