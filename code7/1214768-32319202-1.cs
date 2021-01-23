    namespace MyDOM
    {
        internal class Root
        {
            internal ChildA childA { get; set; }
            internal ChildB childB { get; set; }
            internal static Root CreateExampleDocument()
            {
                Root r = new Root();
                r.childA = new ChildA();
                r.childB = new ChildB();
                r.childA.ResponseCode = "I have my reasons!";
                r.childA.ReasonCode = "I have response code using T4!";
                return r;
            }
        }
        internal class ChildA
        {
            internal string ResponseCode { get; set; }
            internal string ReasonCode { get; set; }
        }
        internal class ChildB
        {
        }
    }
