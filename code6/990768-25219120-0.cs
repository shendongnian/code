    public class Specie
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public Task ParentTask { get; set; }
        public ICollection<Specie> CurrentSpecies { get; set; }
        
        public ICollection<Specie> HistSpecies { get; set; }
    }
