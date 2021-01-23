    class CommandGrammar : Grammar    //define your own grammar
    {
        public CommandGrammar(bool caseSensitive = false) 
            : base(caseSensitive)
        {
            var Command = new NonTerminal("Command");
            Command.Rule = ToTerm("GO") | "STOP" | "STAY";   
                            //these 3 tokens are called "command"
            var And = new NonTerminal("And", ToTerm("AND"));
            var Or = new NonTerminal("Or", ToTerm("OR"));
            var Not = new NonTerminal("Not", ToTerm("NOT"));
                           //define 3 logical operators
            var UnaryOperator = new NonTerminal("UnaryOperator");
            var BinaryOperator = new NonTerminal("BinaryOperator");
            var SimpleExp = new NonTerminal("SimpleExp");
            var ParenthesizedExp = new NonTerminal("ParenthesizedExp");
            var UnaryExp = new NonTerminal("UnaryExp");
            var BinaryExp = new NonTerminal("BinaryExp");
            var Exp = new NonTerminal("Exp");
                      //there are some possible expressions
            //here are the rules for parsing the expression
            UnaryOperator.Rule = Not;            
            BinaryOperator.Rule = And | Or;
            SimpleExp.Rule = Command;
            ParenthesizedExp.Rule = "(" + Exp + ")";
            UnaryExp.Rule = (UnaryOperator + SimpleExp) | (UnaryOperator + ParenthesizedExp);
            BinaryExp.Rule = Exp + BinaryOperator + Exp;
            Exp.Rule = SimpleExp | ParenthesizedExp | UnaryExp | BinaryExp;
        }
    }
