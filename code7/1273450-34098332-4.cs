        class BaseModel
        {
            public string sharedProperty1 { get; set; }
            public string sharedProperty2 { get; set; }
            public string sharedProperty3 { get; set; }
            public string sharedProperty4 { get; set; }
            public string sharedProperty5 { get; set; }
            public string sharedProperty6 { get; set; }
    
            public BaseModel(BaseModel t)
            {
                //assign template properties 
            }
            public BaseModel()
            {
            }
        }
    
    
        class ExtendedModelA : BaseModel
        {
            public string exclusivePropertyA { get; set; }
    
            public ExtendedModelA(BaseModel t)
                : base(t)
            {
    
            }
        }
    
        class ExtendedModelB : BaseModel
        {
            public string exclusivePropertyB { get; set; }
    
            public ExtendedModelB(BaseModel t)
                : base(t)
            {
    
            }
        }
