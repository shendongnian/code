    class Program
    {
        static void Main(string[] args)
        {
            Vector A=new Vector(Unit.Foot, 0.3, 0.5, 0.7, 1.0);
            Vector B=A.ConvertTo(Unit.Inch);
            Vector C=B*B; // Convert to square inches, compatible with SI units of m^2
            Debug.WriteLine(A.ToString());  // [0.3,0.5,0.7,1]
            Debug.WriteLine(B.ToString());  // [3.6,6,8.4,12]
            Debug.WriteLine(C.ToString());  // [12.96,36,70.56,144]
            Vector F=new Vector(Unit.PoundForce, 100.0, 130.0, 150.0, 180.0);
            Vector K=F/B;   // Stiffness is force per distance, compatible with SI units of kg/m^2
            Vector P=F/C;   // Pressure is force per area, compatible with SI units kg/(m*s^2)
            Debug.WriteLine(F.ToString());  // [100,130,150,180]
            Debug.WriteLine(K.ToString());  // [27.78,21.67,17.86,15]
            Debug.WriteLine(P.ToString());  // [7.716,3.611,2.126,1.25]
        }
    }
