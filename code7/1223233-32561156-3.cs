    abstract class HeterogeneousDictionaryKeyBase
    {
        ...
        public abstract void Accept(IHeterogeneousDictionaryKeyVisitor visitor);
        ...
    }
    sealed class HeterogeneousDictionaryKey<TValue> : HeterogeneousDictionaryKeyBase
    {
        ...
        public override void Accept(IHeterogeneousDictionaryKeyVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
