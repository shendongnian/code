    public class MyMethodQuery
    {
        public string Id { get; set; }
    
        public MyMethodQuery(string initialValue = "1")
        {
            this.Id = initialValue;
            if (string.IsNullOrEmpty(this.Id))
                throw new System.ArgumentException("Parameter cannot be null");
        }
    }
