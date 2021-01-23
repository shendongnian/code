    public class MyClass
    {
        private IDictionary<string, object> session = new Dictionary<string, object>();
        private void methodA()
        {
            session["varA"] = GetSingleValesFromDB();
        }
        private void methodB()
        {
            var varA = session["varA"];
        }
    }
