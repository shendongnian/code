    class TestPlugin
    {
        public string ArithmeticOperator
        {
            get { return ""X^2""; }
        }
        public double PerformCalculation(string value)
        {
            System.Double var = System.Double.Parse(value);
            if (var == 0)
                return 0;
            return System.Math.Pow(var, 2);
        }
    }
