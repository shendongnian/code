    public class TestClass
    {
        public static string testVar = "I can see you!";
        public TestClass() {}
    }
    private class MyForm
    {
        MessageBox.Show(TestClass.testVar);
    }
