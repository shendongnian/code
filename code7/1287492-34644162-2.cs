    public class Testable : Untestable
    {
        protected override int GetRandomNumber()
        {
            // You can return whatever you want for your test here,
            // it depends on what type of behaviour you are faking.
            // You can easily inject values here via a constructor or
            // some public field in the subclass. You can also add
            // counters for times method was called, save the args etc.
            return 4;
        }
    }
