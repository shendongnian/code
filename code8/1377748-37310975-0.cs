    public class ParentTest : ITest
    {
        protected virtual string Speak_Impl()
        {
            return "Meow";
        }
        string ITest.Speak()
        {
            return Speak_Impl();
        }
    }
    public class ChildTest : ParentTest
    {
        protected override string Speak_Impl()
        {
            return "Mooo";
        }
    }
