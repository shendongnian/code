    public class A{
        public static string Aa = "test";
        
        public void test(){
            B.testB(this);
        }
    }
    public class B{
        public static void testB(object sender){
            String className = test.GetType().Name;
            String Bb = A.Aa;
        }
    }
