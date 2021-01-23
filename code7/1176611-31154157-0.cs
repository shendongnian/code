    public interface AaInterface {
       public string GetAa();
    }
    
    public class A : AaInterface 
    {
        public static string Aa = "test";
        public GetAa() { return Aa; }
        public void test()
        {
            B.testB(this);
        }
    }
    
    public class B
    {
        public static void testB(AaInterface pAa)
        {
            string Bb = pAa.GetAa();
        }
    }
