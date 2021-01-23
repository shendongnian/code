    public class SomeOtherClass
    {
        public void SomeMethod()
        {
            Logger.Instance.Append("Some message");
        }
        public void SomeOtherMethod()
        {
            MessageBox.Show(Logger.Instance.Merge());
        }
    }
