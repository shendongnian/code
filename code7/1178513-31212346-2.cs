    public class MethodNameToConsoleAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            Console.WriteLine("Test method name is " + methodUnderTest.Name);
        }
    }
