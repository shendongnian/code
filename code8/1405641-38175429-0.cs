    using System;
    class TestPlugin
    {
        public string ArithmeticOperator
        {
            get { return ""X^2""; }
        }
        public double PerformCalculation(string value)
        {
            Double var = Double.Parse(value);
            if (var == 0)
                return 0;
            return Math.Pow(var, 2);
        }
    }
