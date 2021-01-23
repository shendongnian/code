    public class TestClass
    {
        public string testVar = "I can see you!";
        public TestClass() {}
    }
    private class MyForm
    {
        TestClass tc = new TestClass();
        MessageBox.Show(tc.testVar);
    }
