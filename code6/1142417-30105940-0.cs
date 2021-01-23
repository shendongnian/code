        [TestMethod, ExpectedException(typeof(OverflowException))]
        public void Test108_Byte_Overflow_Test()
        {
            byte max = byte.MaxValue;
            byte mf = (byte)3;
            byte b = checked((byte)(max * mf));
        }
        [TestMethod, ExpectedException(typeof(OverflowException))]
        public void Test108_Int16_Overflow_Test()
        {
            Int16 max = Int16.MaxValue;
            Int16 mf = (Int16)3;
            Int16 i = checked((Int16)(max * mf));
        }
        [TestMethod, ExpectedException(typeof(OverflowException))]
        public void Test109_Int32_Overflow_Test()
        {
            int max = int.MaxValue;
            int mf = 3;
            int i = checked(max * mf);
        }
        [TestMethod, ExpectedException(typeof(OverflowException))]
        public void Test110_Float_Overflow_Test()
        {
            float max = float.MaxValue;
            float mf = 3f;
            float f = checked(max * mf);
        }
