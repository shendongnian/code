    [Table("Sys_Nav_FunctionHierarchy")]
    public class Sys_Nav_FunctionHierarchyEntity
    {
        public Sys_Nav_FunctionHierarchyEntity()
        {
        }
        [Key, ForeignKey("Sys_Nav_FunctionEntity")]
        [Required]
        public int Function_ID { get; set; }
        public int Parent_Function_ID { get; set; }
        public Sys_Nav_FunctionEntity Sys_Nav_FunctionEntity { get; set; }
    }
