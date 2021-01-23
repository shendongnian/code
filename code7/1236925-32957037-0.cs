    public static class ExtensionMethods
    {
        public static Point Add(this Point operand1, Point operand2)
        {
            return new Point(operand1.X + operand2.X, operand1.Y + operand2.Y);
        }
    }
