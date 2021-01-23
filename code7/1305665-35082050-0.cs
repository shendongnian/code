    public class A : B
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
    }
    
    public class B : C
    {
        public int LocationId { get; set; }
        public int DepID { get; set; }
    }  
    
    public class C
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
