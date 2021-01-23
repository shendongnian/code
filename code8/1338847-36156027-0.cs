    public class EntityA
    {
        public int Id { get; set; }
        public virtual EntityB EntityB { get; set; }
    }
    public class EntityB
    {
        public int Id { get; set; }
        public virtual EntityA EntityA { get; set; }
    }
