    interface ISub1A: IBaseA
    {
        int Prop3 { get; set; }
    }
    
    interface IBaseA
    {
        int Prop1 { get; set; }
        string Prop2 { get; set; }
    }
    
    interface ISub1B: IBaseB
    {
        int Prop3 { get; set; }
        string Prop2 { get; set; }
    }
    
    interface IBaseB
    {
        int Prop1 { get; set; }
    }
