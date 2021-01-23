        [Flags]
        public enum MyEnum
        {
            Foo = 1,
            Bar = 2,
            Bizz = 4,
            Buzz = 8,
            Boo = 16
        }
    var foo = MyEnum.Foo | MyEnum.Foo | MyEnum.Bizz;
    // foo == MyEnum.Foo | MyEnum.Bizz because setting the same flag twice does nothing
    var bar = (MyEnum)27 // Some invalid combination
    // bar == 27.  Why would you do this instead of MyEnum.Boo | MyEnum.Buzz | MyEnum.Bar | MyEnum.Foo
