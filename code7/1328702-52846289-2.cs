    public partial class Example<T> where T: BaseModel
    {
        public int Id { get; set; }
        public T Data { get; set; } // so here could be any Child of BaseModel
    }
    public partial class Example: Example<BaseModel> 
    {
    }
