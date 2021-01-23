    [Binding]
    public class EmployeeSteps
    {
        [Given(@"I Add New '(.*)'")]
        public void GivenIAddNew(string p0)
        {
            Console.WriteLine(p0);
        }
    }
