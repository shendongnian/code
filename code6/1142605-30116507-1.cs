    public class Employee : BaseEntity
    {
        ...
        // reference
        public virtual Department Dept { get; set; }
        // reference_ID also mapped as integer
        public virtual int? DeptId { get; set; }
    }
    
    EmployeeMap : ClassMap<Employee>
    {
         Reference(x => x.Dept).Column("DeptId");
         Map(x => x.DeptId)
             // with .Not.Nullable() by code or convention
             ; 
    }
