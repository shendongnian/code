    public class Wrapper<T>
    {
        public Type MyType{get;set;}
        public T Data { get; set; }
        public string[] Metadata { get;set;}
    
        public Wrapper(T data){
          MyType = data.GetType();
          Data = data; 
        }
    }
