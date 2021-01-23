    static void Main(string[] args)
    {
        StepOne("dd", "12+");
        Console.ReadLine();
    }
    
    public static void StepOne(string command, string user_input)
    {
        // NOTE: 'command' and 'user_input' are both provided by parsing the
        // user's input via a graphical interface (I'm simplifying here because
        // I don't want this to get cluttered with regex stuff).
    
        // Creating the Expression instance:
        Expression target_expr = new Expression(Terp.ToPostfix(user_input));
    
        // Setting up console messages to make sure the input is there:
        Console.WriteLine("Command: '" + command + "'");
        Console.WriteLine("Expression: '" + Terp.CompileString(target_expr.Value) + "'");
    
        // Passing 'Expression' object into 'StepTwo()':
        StepTwo(command, target_expr);
    }
    
    static void StepTwo(string command, Expression target_expr)
    {
        // Making sure everything made it through the Stargate alright:
        Console.WriteLine("------------------------------");
        Console.WriteLine("Command: '" + command + "'");
        Console.WriteLine("Expression: '" + Terp.CompileString(target_expr.Value) + "'");
    }
