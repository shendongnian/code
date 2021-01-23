    [Table("Sys_Nav_FunctionHierarchy")]
    public class Sys_Nav_FunctionHierarchyEntity
    {
        public Sys_Nav_FunctionHierarchyEntity()
        {
    
        }
    
    
        [Key, Column(Order =0)]
        public int Hierarchy_ID { get; set; }
    
        [ForeignKey("Function_ID"), Column(Order =1)]
        public int Function_ID { get; set; }
    
        public int Parent_Function_ID { get; set; }
    
        public Sys_Nav_FunctionEntity Sys_Nav_FunctionEntity { get; set; }
    }
