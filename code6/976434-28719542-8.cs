    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class InlineAutoDataAttribute : AutoDataAttribute
    {
        private readonly object[] values;
        public InlineAutoDataAttribute(params object[] values)
            : base(new Fixture().Customize(new AutoMoqCustomization()))
        {
            this.values = values;
        }
        public override IEnumerable<object[]> GetData(MethodInfo method)
        {
            var testCaseData = base.GetData(method);
            foreach (object[] caseValues in testCaseData)
            {
                if (values.Length > caseValues.Length)
                {
                    throw new InvalidOperationException("Number of parameters provided is more than expected parameter count");
                }
                Array.Copy(values, caseValues, values.Length);
                yield return caseValues;
            }
        }
    }
