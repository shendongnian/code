    public class CalcFix
    {
        struct OperStruct
        {
            public Action<int> OperFunc;
            public int OperValue;
            public static OperStruct OperSet(Action<int> _operFunc, int _operValue)
            {
                OperStruct operStru = new OperStruct();
                operStru.OperFunc = _operFunc;
                operStru.OperValue = _operValue;
                return operStru;
            }
        }
        private bool _undo = false;
        private int _total = 0;
        private Dictionary<Action<int>, Action<int>> _reverseOper = new Dictionary<Action<int>, Action<int>>();
        private Stack<OperStruct> stack = new Stack<OperStruct>();
        public CalcFix()
        {
            _reverseOper.Add(Add, Subtract);
            _reverseOper.Add(Subtract, Add);
            _reverseOper.Add(Multiply, Division);
            _reverseOper.Add(Division, Multiply);
        }
        public int Value { get { return _total; } }
        public void Add(int value)
        {
            _total += value;
            _undo = false;
            stack.Push(OperStruct.OperSet(Add, value));
        }
        public void Subtract(int value)
        {
            _total -= value;
            _undo = false;
            stack.Push(OperStruct.OperSet(Subtract, value));
        }
        public void Multiply(int value)
        {
            _total *= value;
            _undo = false;
            stack.Push(OperStruct.OperSet(Multiply, value));
        }
        public void Division(int value)
        {
            _total /= value;
            _undo = false;
            stack.Push(OperStruct.OperSet(Division, value));
        }
        public void Undo()
        {
            OperStruct operFunc = stack.Pop();
            if (operFunc.OperFunc != null && _reverseOper.ContainsKey(operFunc.OperFunc))
            { 
                _reverseOper[operFunc.OperFunc](operFunc.OperValue);
                _undo = true;
            }
        }
        public void RepeatLastCommand()
        {
            OperStruct topOfStack = stack.Peek();
            if (stack.Count > 1)
            {
                if (topOfStack.OperFunc != null)
                {
                    if (!_undo) // if not called undo
                        _reverseOper[topOfStack.OperFunc](topOfStack.OperValue);
                    else // called undo
                    {
                        stack.Pop();
                        topOfStack = stack.Pop();
                        _reverseOper[topOfStack.OperFunc](topOfStack.OperValue);
                        _undo = true;
                    }
                }
            }
        }
    }
    public static void TestTwo()
    {
        var c = new CalcFix();
        c.Add(2);
        c.Add(3);
        c.Add(4);
        System.Console.WriteLine(c.Value);
        c.Undo();
        System.Console.WriteLine(c.Value);
        c.RepeatLastCommand();
        System.Console.WriteLine(c.Value);
        c.RepeatLastCommand();
        System.Console.WriteLine(c.Value);
    }
    static void Main(string[] args)
    { 
        TestTwo();
    }
