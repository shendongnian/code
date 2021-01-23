    public abstract class DecoratorBase<T> : ValidatableBindableBase
    {
        public virtual void SetFields(T param) { }
        public virtual void SetFieldsBack(ref T param) { }
    }
