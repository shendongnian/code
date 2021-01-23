    public class Car
    {
        public Int32 ID { get; set; }
        public DateTime Make { get; set; }
        public String Model { get; set; }
        public override string ToString()
        {
           return String.Format("{0} - {1}", this.Make, this.Model);
        }
    }
