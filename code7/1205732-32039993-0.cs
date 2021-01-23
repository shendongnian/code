    public class Register
    { 
        public int Id { get; set; }
        public string Number { get; set; }
       
        public virtual CustomerDisplay CustomerDisplay { get; set; }
    }
