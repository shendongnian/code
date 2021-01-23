    class MutableTuple<T1, T2> : Tuple<T1, T2>
    {
        private static readonly FieldInfo FieldInfoItem1 = typeof (Tuple<T1, T2>).GetField("m_Item1", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly FieldInfo FieldInfoItem2 = typeof (Tuple<T1, T2>).GetField("m_Item2", BindingFlags.NonPublic | BindingFlags.Instance);
        public MutableTuple(T1 item1, T2 item2) : base(item1, item2)
        {
        }
        public void SetItem1(T1 item1)
        {
            FieldInfoItem1.SetValue(this, item1);
        }
        public void SetItem2(T2 item2)
        {
            FieldInfoItem2.SetValue(this, item2);
        }
    }
