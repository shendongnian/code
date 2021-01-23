    var cb1 = new ContractBase
    {
        CommonKey = "Value",
        ObjType = "A",
        Obj = new Obj
        {
            CommonObjKey = "Value",
            ObjKey = 1234
        }
    };
    
    var cb2 = new ContractBase
    {
        CommonKey = "Value",
        ObjType = "A",
        Obj = new Obj
        {
            CommonObjKey = "Value",
            ObjKey = "Value"
        }
    };
    class ContractBase 
    {
        public string CommonKey { get; set; }
        public string ObjType { get; set; }
        public Obj Obj { get; set; }
    }
    
    class Obj
    {
        public string CommonObjKey { get; set; }
        public dynamic ObjKey { get; set; }
    }
