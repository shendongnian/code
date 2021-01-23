    [Serializable]
    class BinaryExpression : ExpressionSyntaxNode, ISerializable
    {
        private ExpressionSyntaxNode left;
        private ExpressionSyntaxNode right;
        private Operator optr;
        public BinaryExpression(ExpressionSyntaxNode left, ExpressionSyntaxNode right, Operator optr)
        {
            this.left = left;
            this.right = right;
            this.optr = optr;
        }
        #region ISerializable Members
        protected BinaryExpression(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            left = (ExpressionSyntaxNode)info.GetValue("left", typeof(ExpressionSyntaxNode));
            right = (ExpressionSyntaxNode)info.GetValue("right", typeof(ExpressionSyntaxNode));
            optr = (Operator)info.GetValue("optr", typeof(Operator));
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("left", left);
            info.AddValue("right", right);
            info.AddValue("optr", optr);
        }
        #endregion
        public override string ToString()
        {
            return string.Format("({0} {1} {2})", left.ToString(), optr.ToString(), right.ToString());
        }
    }
