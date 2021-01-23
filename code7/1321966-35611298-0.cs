    public class ParentModel
    {
        public Guid Id { get; set; }
        public virtual ICollection<ChildModel> Children { get; set; }
    }
