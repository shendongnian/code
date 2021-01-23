    public class F1
    {
        private int _field1;
        public int Field1 { get return _field1; }
        private int _field2;
        public int Field2 { get return _field2; }
        private int _field3;
        public int Field3 { get return _field3; }
        ...
        public F1 SetField1(int f)
        {
            var f1 = (F1)MemberwiseClone();
            f1._field1 = f;
            return f1;
        }
        ...
    }
