    public class OpWrapper
    {
        public int operands;      //the number of operands this operator needs.
        public int precedence;    //the precedence this operator gets when calculating.
        public bool rightAssoc;   //whether or not this operator is right associative (true) or left associative (false).
        public object func;
        //constructor initializes all variables.
        public OpWrapper(int p, Func<double, double> f, bool a = false)
        {
            //No need to pass in o, we can infer from context that its a single parameter
            operands = 1;
            precedence = p;
            rightAssoc = a;
            func = f;
        }
        //overloaded constructor assigns the proper method.
        public OpWrapper(int p, Func<double, double, double> f, bool a = false)
        {
            //No need to pass in o, we can infer from context that its a double parameter
            operands = 2;
            precedence = p;
            rightAssoc = a;
            func = f;
        }
        public double evaluate(params double[] values)
        {
            if (values.Length != operands)
                throw new InvalidOperationException("Invalid number of operands");
            //do stuff
            if (operands == 1)
            {
                return ((Func<double, double>)func)(values[0]);
            }
            else
            {
                return ((Func<double, double, double>)func)(values[0], values[1]);
            }
            //more stuff
        }
    }
