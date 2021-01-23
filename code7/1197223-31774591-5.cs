    public class Test
    {
        public void TestCallingMyTestMethod()
        {
            this.MyTestMethod(A.A1);
            this.MyTestMethod(B.B1);
            this.MyTestMethod(C.C1);
        }
        public void MyTestMethod(A_B_C_Caster classA_B_C)
        {
            var value = classA_B_C.Value;
        }
    }
