    public class Authority
    {
        [InverseProperty("UsedFor")]    
        public List<Authority> UsedFor { get; set; }
        [InverseProperty("Equivalent")]  
        public List<Authority> Equivalent { get; set; }    
    }
