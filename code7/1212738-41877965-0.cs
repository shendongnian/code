        public static dynamic GetValue(this Mat mat, int row, int col)
        {
            var value = CreateElement(mat.Type());
            Marshal.Copy(mat.Data + (row * mat.Cols + col) * mat.ElemSize(), value, 0, 1);
            return value[0];
        }
        public static void SetValue(this Mat mat, int row, int col, dynamic value)
        {
            var target = CreateElement(mat.Type(), value);
            Marshal.Copy(target, 0, mat.Data + (row * mat.Cols + col) * mat.ElemSize(), 1);
        }
        private static dynamic CreateElement(MatType depthType, dynamic value)
        {
            var element = CreateElement(depthType);
            element[0] = value;
            return element;
        }
        private static dynamic CreateElement(MatType depthType)
        {
            switch (depthType)
            {
                case MatType.CV_8S:
                    return new sbyte[1];
                case MatType.CV_8U:
                    return new byte[1];
                case MatType.CV_16S:
                    return new short[1];
                case MatType.CV_16U:
                    return new ushort[1];
                case MatType.CV_32S:
                    return new int[1];
                case MatType.CV_32F:
                    return new float[1];
                case MatType.CV_64F:
                    return new double[1];
                default:
                    throw new NotImplementedException();
            }
        }
