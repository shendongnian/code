    class MyVisitor : MyGrammarNameVisitor<object>
    {
        public readonly List<MyErrorType> errors = new List<MyErrorType>();
        override object visitMyRuleName(MyGrammarName.MyRuleNameContext ctx){
            if (erroneous)
            {
                errors.Add(new MyErrorType(linenumber, column, errorMessage, whateverElseMayBeUseful));
                return null;
            }
            //...
        }
    }
