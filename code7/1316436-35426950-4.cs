    public class Result<T> where T : class
    {
        public Result() { }
    
        public Result(T data)
        {
            this.Data = data;
        }
    
        public T Data { get; set; }
    
    }
