    [Table("Sys_Nav_FunctionHierarchy")]
    public class Sys_Nav_FunctionHierarchyEntity
    {
        //...
        public int Function_ID { get; set; }
        [ForeignKey("Function_ID")]
        public Sys_Nav_FunctionEntity Sys_Nav_FunctionEntity { get; set; }
    }
