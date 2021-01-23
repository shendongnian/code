    public class AString : A<string>
    {
        public AString(B<string> b) : base(b)
        {
        }
        public override string FuncOne()
        {
            B.Value = "New Value";
            return B.Value;
        }
    }
    var thisB = new B<string>()
    thisB.Value = "Test"
    var thisA = new AString(thisB);
    var value = thisA.FuncOne();
    var thisValue = thisB.Value;
