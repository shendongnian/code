    public partial class Cuisine
    {
        public int Id { get; set; }
    
        [Display(Name="Name of Cuisine")]
        public string Name { get; set; }
    
        public virtual ICollection<Dish> Dishes { get; set; }
    }
