    public class CalculationParameters
    {
        public double LeftNumber {get;set;}
        public string Operator {get;set;}
        public double RightNumber {get;set;}
        public double Result {get;set;}
        public override string ToString(){ return $"{LeftNumber} {Operator} {RightNumber} = {Result}"; }
    }
    public void WhenPerformingCalculation_ThenResultIsCorrect() {
        ICollection<CalculationParameters> parameters = getParameters();
        List<Exception> exceptions = new List<Exception>();
        foreach(CalculationParameters parameter in parameters)
        {
            try
            {
                var testResult =
                modelUnderTest.LeftSideNumber.SetValue(parameter.LeftNumber) // set first number
                              .Operator.SetValue(parameter.Operator) // set sign
                              .RightSideNumber.SetValue(parameter.RightNumber) // set right number
                              .Evaluate.Click() // press evaluate button
                              .Result; // get the result
                Assert.AreEqual(testResult, parameter.Result);
            }
            catch (Exception e)
            {
               exceptions.Add(new Exception($"Failed for parameters: {parameter}", e));
            }
        }
        if(exceptions.Any()){
            throw new AggregateException(exceptions);
        }
    }
