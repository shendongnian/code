    public class Info
    {
        public string Info1 { get; set; }
        public bool Info2 { get; set; }
    
        public Info(Pineapple p)
        {
            this.Info1 = p.State;
            this.Info2 = p.Ripe;
        }
    
        public Info(Bean b)
        {
            this.Info1 = b.Type;
            this.Info2 = b.Bloats;
        }
    }
