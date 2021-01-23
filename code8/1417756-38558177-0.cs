    public A() 
    {  
        private readonly InterfaceB _b;
        
        public A(InterfaceB b)
        {
            _b = b;
        }
        public string functionA() 
        {
            if(String.IsNullOrEmpty(_b.GetId())) return String.Empty;
            else if(String.IsNullOrEmpty(_b.GetKey())) return String.Empty;
            else  return _b.GetToken(); 
         } 
    } 
