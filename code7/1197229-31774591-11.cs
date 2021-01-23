    public class Test
    {
        static void Main()
        {
            MyTestMethod(A.A1);
            MyTestMethod(B.B2);
            MyTestMethod(C.C3);
            Console.ReadKey();
        }
        static void MyTestMethod(MultiIntEnum<int, A,B,C> classA_B_C)
        {
            var value = classA_B_C.Value;
            Console.WriteLine(value);
        }
    }
