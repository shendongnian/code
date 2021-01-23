    public class MenuVM
    {
        public int? ID { get; set; } // included so this can be used for editing as well as creating
        public string Name { get; set; }
        public int AmountPersons { get; set; }
        public List<DishVM> Dishes { get; set; }
    }
    public class DishVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
