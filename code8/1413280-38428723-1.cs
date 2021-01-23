    public class CategoryEnt
    {
        public Category CategoryPrimaryDetails { get; set; }
        public int ParentID { get; set; }
        public bool IsDisplayed { get; set; }
        public bool IsTopCat { get; set; }
        public bool IsTrending { get; set; }
        public int SequenceID { get; set; }
        public string Filtering { get; set; }
    }
