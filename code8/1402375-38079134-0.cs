    class MyBusiness<T> where T: new()
    {
        public List<T> coll { get; set; }
        
        public MyBusiness(){
            coll = new List<T>();
        }
        public void DoSth(){
            T t = new T();
            coll.Add(t);
        }
    }
