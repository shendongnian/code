        public class BaseEntity
        {
            [Key]
            [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
        }
        public class TestEntity1 : BaseEntity
        {
            public string Name { get; set; }
        }
        public class TestEntity2 : BaseEntity
        {
            public string Name2 { get; set; }
        }
