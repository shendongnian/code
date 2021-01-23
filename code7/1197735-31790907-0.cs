    class BaseEntity {
        [Key]
        public int KeyPartBase {get;set;}
    }
    class DerivedEntity : BaseEntity {
        [Key]
        public int KeyPartDerived {get;set;}
    }
