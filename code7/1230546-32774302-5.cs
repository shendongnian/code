        public static IEnumerable<Foo<Bar>> ToFoo(this IEnumerable<Bar> bars, IEnumerable<Qux> quxs)
        {
            return bars.
                Select(bar => new Foo<Bar>(bar, quxs.Single(qux => qux.ID == bar.BarQux))).ToList();
        }
        public static IEnumerable<Foo<Baz>> ToFoo(this IEnumerable<Baz> bazs, IEnumerable<Qux> quxs)
        {
            return bazs.
                Select(baz => new Foo<Baz>(baz, quxs.Single(qux => qux.ID == baz.BazQux))).ToList();
        }
        public static IEnumerable<Qux> ToQuxes(this IEnumerable<BazQux> bazQuxs)
        {
            return bazQuxs.Select(b => new Qux(typeof(BazQux), b)).ToList();
        }
        public static IEnumerable<Qux> ToQuxes(this IEnumerable<BarQux> barQuxes )
        {
            return barQuxes.Select(b => new Qux(typeof(BarQux), b)).ToList();
        }
