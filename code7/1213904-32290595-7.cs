    public class Calc
    {
        bool undoAction = false;
        int total = 0;
        Stack<CalcAction> stack = new Stack<CalcAction>();
    
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
    
        public void Add(int value)
        {
            CalcAction act = new CalcAction() 
            { 
                operation = Add, 
                actionTotal = total + value, 
                actionValue = value 
            };
            total = act.actionTotal;
            stack.Push(act);
            undoAction = false;
        }
    
        public void Subtract(int value)
        {
            CalcAction act = new CalcAction()
            {
                operation = Subtract,
                actionTotal = total - value,
                actionValue = value
            };
            total = act.actionTotal;
            stack.Push(act);
            undoAction = false;
        }
    
        public void Multiply(int value)
        {
            CalcAction act = new CalcAction()
            {
                operation = Multiply,
                actionTotal = total * value,
                actionValue = value
            };
            total = act.actionTotal;
            stack.Push(act);
            undoAction = false;
        }
    
        public void RepeatLastCommand()
        {
            if (stack.Count > 0)
            {
                if(undoAction)
                    Undo();
                else
                {
                    CalcAction act = stack.Peek();
                    act.operation(act.actionValue);
                }
            }
        }
    
        public void Undo()
        {
            if (stack.Count > 0) stack.Pop();
            total = ((CalcAction)stack.Peek()).actionTotal;
            undoAction = true;
        }
    
        internal class CalcAction
        {
            public Action<int> operation;
            public int actionValue;
            public int actionTotal;
        }
    }
