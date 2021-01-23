    public abstract class BaseModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public partial class Child1 : BaseModel
    {
         public string Name1 { get; set; }
    }
    public partial class Child2 : BaseModel 
    {
        public string Name2 { get; set; }
    }
