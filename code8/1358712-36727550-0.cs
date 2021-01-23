    public class TheBaseClass
    {
        public readonly List<string> Output = new List<string>();
        public virtual void WriteToOutput()
        {
            Output.Add("TheBaseClass");
        }
    }
    public class TheDerivedClass : TheBaseClass
    {
        public override void WriteToOutput()
        {
            Output.Add("TheDerivedClass");
            base.WriteToOutput();
        }
    }
