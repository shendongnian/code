    [Serializable]
    abstract class ExpressionSyntaxNode : ISerializable
    {
        protected ExpressionSyntaxNode()
        {
        }
        #region ISerializable Members
        protected ExpressionSyntaxNode(SerializationInfo info, StreamingContext context)
        {
        }
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
        #endregion
    }
    [Serializable]
    abstract class ValueExpression<T> : ExpressionSyntaxNode, ISerializable where T : IConvertible
    {
        T value;
        public T Value { get { return value; } }
        public ValueExpression(T value)
        {
            this.value = value;
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("value", value);
        }
        protected ValueExpression(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.value = (T)info.GetValue("value", typeof(T));
        }
        public override string ToString()
        {
            if (value == null)
                return "";
            return value.ToString();
        }
    }
    [Serializable]
    class BooleanExpression : ValueExpression<bool>, ISerializable
    {
        public BooleanExpression(bool value) : base(value) { }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        protected BooleanExpression(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
    [Serializable]
    public enum Operator
    {
        And,
        Or
    }
