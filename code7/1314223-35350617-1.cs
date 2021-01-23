        protected class Comparison : Attribute
        {
            public ExpressionType Type;
            public Comparison(ExpressionType type)
            {
                Type = type;
            }
        }
        protected class LinkedField : Attribute
        {
            public string TargetField;
            public LinkedField(string target)
            {
                TargetField = target;
            }
        }
