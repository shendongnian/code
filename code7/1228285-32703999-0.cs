    public interface IMyInterface
    {
        bool AmITrue { get; set; }
    }
    public class Class1 : IMyInterface
    {
        public bool AmITrue { get; set; }
        public bool AmIAnotherMethod { get; set; }
    }
    public class MainClass
    {
        public MainClass()
        {
            IMyInterface limitedClass = new Class1();
            var works = limitedClass.AmITrue;
            var doesNotWork = limitedClass.AmIAnotherMethod;
        }
    }
