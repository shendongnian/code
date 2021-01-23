    class NavigationFilter
    {
        [PropertyDeclaringType(typeof(Foo))]
        [PropertyName("Bars")]
        public static Expression<Func<Bar,bool>> OnlyReturnBarsWithSpecificSomeValue()
        {
            var someValue = SomeClass.GetAValue();
            return b => b.SomeValue == someValue;
        }
    }
