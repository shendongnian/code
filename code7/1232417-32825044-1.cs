    interface IObject<O, I> where O : IObject<O, I>, I
    { }
    interface IUnit<I> : IObject<IUnit<I>, I>
    {
    }
