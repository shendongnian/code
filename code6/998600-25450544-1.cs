    public interface Testable {
        void doTest();
    }
    public class Test1 implements Testable {
        // implement doTest()
    }
    private static Testable[] testables = new Testabable[] {
        new Test1()
    };
    // now iterate your testables and call doTest()
