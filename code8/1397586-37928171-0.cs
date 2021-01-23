    public interface IFoo
    {
    }
    public interface IBar
    {
    }
    public interface IFoo<TFoo, TBar> : IFoo
        where TFoo : IFoo
        where TBar : IBar
    {
    }
    public interface IBar<TFoo, TBar> : IBar
        where TFoo : IFoo
        where TBar : IBar
    {
    }
