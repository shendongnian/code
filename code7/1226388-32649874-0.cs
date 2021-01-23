    public abstract class Vehicle
    {
        protected Vehicle() 
        {
            this.Incidents= new List<Incident>();
        }
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Incident> Incidents{ get; set; }
    }
