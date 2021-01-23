    public class B : I
    {
        public int ID { get; set; }
        public string PropB { get; set; }
        public B(source B)
        {
            // copy values
            this.ID = source.ID;
            this.PropB = source.PropB;
        }
    }
