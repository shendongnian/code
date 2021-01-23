    private double Function(double t, double y)
        {
            NCalc.Expression expression = new NCalc.Expression(this.Expression);
            expression.Parameters["t"] = t;
            expression.Parameters["y"] = y;
            double value;
            double.TryParse(expression.Evaluate().ToString(), out value);
            return value;        
        }
