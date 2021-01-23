    public class someClass : ic
    {
        string Prop3 { get; set; }
        public static explicit operator someClass(c1 c1o)
        {
            return new someClass { Prop3 = c1o.Prop3 };
        }
    }
    // which should allow this...
    c1 c1o = new c1() { Prop3 = "test" };
    string res = ((ic)c1o).Prop3;
