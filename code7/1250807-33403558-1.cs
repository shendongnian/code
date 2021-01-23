    static class SomeClassMeetsConditionName
    {
        private static Expression<Func<SomeClass,bool>> _expression;
        private static Func<SomeClass,bool> _delegate;
        static SomeClassMeetsConditionName()
        {
            _expression = x => (x.A > 3 && !x.B.HasValue) || (x.B.HasValue && x.B.Value > 5);
            _delegate = _expression.Compile();
        }
        public static Expression<Func<SomeClass, bool>> Expression { get { return _expression; } }
        public static Func<SomeClass, bool> Delegate { get { return _delegate; } }
    }
