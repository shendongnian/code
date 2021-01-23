    public class someClass : ic
    {
        string Prop3 { get; set; }
    }
    //...
    c1 c1o = new c1() { Prop3 = "test" };
    string res = (new someClass { Prop3 = c1o.Prop3 }).Prop3;
