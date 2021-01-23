    public interface C1 { }
    public class C2 : C1 { }
    public interface MK<out T> { }   // use <out T> instead of <T>
    public struct MKSub : MK<C2> { }
    public class Test
    {
        void Something()
        {
            MK<C1> test = new MKSub();    // this compiles
        }
    }
