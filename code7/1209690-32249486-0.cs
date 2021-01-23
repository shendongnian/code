    public static class ExtensionMethods
    {
        public static PointF Add(this PointF operand1, PointF operand2)
        {
            return new PointF(operand1.X + operand2.X, operand1.Y + operand2.Y);
        }
    }
