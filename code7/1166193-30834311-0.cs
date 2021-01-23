    public class CourseModel
    {
        public int CourseModelId { get; set; }
        public virtual ICollection<Ints> Ints { get; set; } // See the difference?
        public string Name { get; set; }
        public string Overview { get; set; }
    }
