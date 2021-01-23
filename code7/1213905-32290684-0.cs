    public class Calc
    {
        int total = 0;
        struct OperatorInfo
        {
            public enumOperatior Operator; // 0 add 1 sub 2 mul 3
            public int Value;
        }
        enum enumOperatior
        {
            Add, Subtract, Multiply
        };
        Stack<OperatorInfo> stack = new Stack<OperatorInfo>();
        public int Value
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
            }
        }
        private void Operation(int value, enumOperatior oper)
        {
            OperatorInfo _oper = new OperatorInfo();
            _oper.Operator = oper;
            _oper.Value = value;
            stack.Push(_oper);
            switch (oper)
            {
                case enumOperatior.Add:
                    {
                        total = total + value;
                        break;
                    }
                case enumOperatior.Subtract:
                    {
                        total = total - value;
                        break;
                    }
                case enumOperatior.Multiply:
                    {
                        total = total * value;
                        break;
                    }
            }
        }
        public void Add(int value)
        {
            Operation(value, enumOperatior.Add);
        }
        public void Subtract(int value)
        {
            Operation(value, enumOperatior.Subtract);
        }
        public void Multiply(int value)
        {
            Operation(value, enumOperatior.Multiply);
        }
        public void RepeatLastCommand()
        {
            OperatorInfo topOfStack = stack.Peek();
            switch (topOfStack.Operator)
            {
                case enumOperatior.Add:
                    {
                        total -= topOfStack.Value; // sub
                        break;
                    }
                case enumOperatior.Subtract:
                    {
                        total += topOfStack.Value; // add
                        break;
                    }
                case enumOperatior.Multiply:
                    {
                        total /= topOfStack.Value; // div
                        break;
                    }
            }
        }
        public void Undo()
        {
            OperatorInfo operInfo = stack.Pop(); 
            switch (operInfo.Operator)
            {
                case enumOperatior.Add:
                    {
                        total -= operInfo.Value; // sub
                        break;
                    }
                case enumOperatior.Subtract:
                    {
                        total += operInfo.Value; // add
                        break;
                    }
                case enumOperatior.Multiply:
                    {
                        total /= operInfo.Value; // div
                        break;
                    }
            }
        }
    }
    public static void TestOne()
    {
        // (5-2)*3
        var c = new Calc();
        c.Add(5);
        c.Add(7); 
        c.Undo(); 
        c.Subtract(2);
        c.Multiply(7);
        c.Undo();
        c.Multiply(3);
        System.Console.WriteLine(c.Value);
    }
    public  static void TestTwo()
    {
        var c = new Calc();
        c.Add(2);
        c.Add(3);
        c.Add(4);
        c.Undo();
        c.RepeatLastCommand();
        System.Console.WriteLine(c.Value);
    }
    static void Main(string[] args)
    {
        TestOne();
        TestTwo();
    }
