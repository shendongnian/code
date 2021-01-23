    InputField evalInput;
    void Start()
    {
        StartCoroutine(Eval("Your Expression"));
        evalInput = GameObject.Find("EvalInput").GetComponent<InputField>();
    }
    double evalResult = 0;
    public IEnumerator Eval(string expression)
    {
        Stack<string> ops = new Stack<string>();
        Stack<double> vals = new Stack<double>();
        string s = expression;
        while (!s.Equals(""))
        {
            s = evalInput.text; //Modify the string here (Empty string == Exit)
            if (s.Equals("(")) ;
            if (s.Equals("+")) ops.Push(s);
            else if (s.Equals("-")) ops.Push(s);
            else if (s.Equals("*")) ops.Push(s);
            else if (s.Equals("/")) ops.Push(s);
            else if (s.Equals("sqrt")) ops.Push(s);
            else if (s.Equals(")"))
            {
                string op = ops.Pop();
                double v = vals.Pop();
                if (op.Equals("+")) v = vals.Pop() + v;
                else if (op.Equals("-")) v = vals.Pop() - v;
                else if (op.Equals("*")) v = vals.Pop() * v;
                else if (op.Equals("/")) v = vals.Pop() / v;
                else if (op.Equals("sqrt")) v = System.Math.Sqrt(v);
                vals.Push(v);
            }
            else vals.Push(double.Parse(s));
            yield return null;
        }
        evalResult = vals.Pop();
    }
