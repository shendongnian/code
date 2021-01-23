    using System.Numerics;
    using System.Runtime.InteropServices;
    
    public unsafe class MyWrapper
    {
        static void Main(string[] args)
        {
            Complex[,] A = new Complex[12000, 12000];
    
            A[0, 0] = new Complex(0.1, -0.1);
            A[0, 1] = new Complex(11.0, 0.1);
            A[0, 5] = new Complex(55, -0.5);
            A[0, 9] = new Complex(99.0, 0.9);
    
            fixed (Complex* p = &A[0, 0])
                C_foo(p);
        }
    
        [DllImport("DLL1.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, SetLastError = false)]
        internal static extern int C_foo(Complex* A);
