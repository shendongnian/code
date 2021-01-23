    public abstract class OptionalParameter
    {
        public string GenerateQueryString()
        {
            // You are calling the extension method here
            return this.GenerateQueryStringWithParameters();
        }
    }
