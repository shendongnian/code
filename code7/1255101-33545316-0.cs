    internal static class Factory
    {
        internal static Dictionary<ThingEnum, Func<IThing>> ctors = new Dictionary<ThingEnum, Func<IThing>>
        {
            {ThingEnum.A, () => new A() },
            {ThingEnum.B, () => new B() },
            {ThingEnum.C, () => new C() }
        };
        internal static IThing MakeThing(ThingEnum type)
        {
            return ctors[type]();
        }
    }
