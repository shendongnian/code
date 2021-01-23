    public enum TypeEnum
    {
        Segunda = 1,
        Terca = 2,
        Quarta = 3,
        Sexta = 4
    }
    public class Type
    {
        public int Id { get; set; }
        public TypeEnum Type { get; set; }
    }
    public class TimeSelections
    {
        public int Id { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public TypeEnum TypeId { get; set; }
        public bool Selected { get; set; }
    }
