    public class Req
    {
        [Range(1, Int32.MaxValue, ErrorMessage = "Enter number greater than 1 ")]
        public int Offset { set; get; }
        public int Limit { set; get; }
    }
