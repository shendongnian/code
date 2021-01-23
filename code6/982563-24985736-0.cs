    public class FooVm
    {
        // some property
        public List<BarVm> Bars { get; set; }
        public FooVm()
        {
            // Make sure the collection exists to prevent NullReferenceException
            this.Bars = new List<BarVm>();
        }
    }
    public class BarVm
    {
        // some property
        [Range( 1, Int32.MaxValue, ErrorMessage = "Must be greater than 1" )]
        public float? Fox { get; set; }
    }
