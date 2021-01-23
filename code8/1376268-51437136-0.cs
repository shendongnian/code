    public struct Country
    {
        string value;
        public static Country BE => "BE";
        public static Country NL => "NL";
        public static Country DE => "DE";
        public static Country GB => "GB";
        private Country(string value)
        {
            this.value = value;
        }
        public static implicit operator Country(string value)
        {
            return new Country(value);
        }
        public static implicit operator string(Country country)
        {
            return country.value;
        }
    }
