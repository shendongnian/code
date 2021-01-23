    public class TestA {
       TestB _testB;
       private class TestB {
       }
       public TestA() {
          _testB = new TestB();
       }
    }
