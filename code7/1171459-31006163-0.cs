    interface IBase0
    {
        int Prop1 { get; set; }
    }
    interface IBase : IBase0
    {
        int Prop1 { get; set; }
        string Prop2 { get; set; }
    }
    interface ISub1: IBase
    {
        int Prop3 { get; set; }
    }
    interface ISub2 : IBase0
    {
        int Prop4 { get; set; }
    }
