    public abstract class Incident
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Incident> VehicleIncidents { get; set; }
    }
