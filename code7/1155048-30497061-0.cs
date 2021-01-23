    public class process
    {
        private Form1 f1 = null;
        public process(Form1 f1)
        {
            this.f1 = f1;
        }
        public void Foo()
        {
            if (f1 != null && !f1.IsDisposed)
            {
                f1.SetProgressMax(10);
                f1.IncrementProgress();
                f1.IncrementProgress();
                f1.IncrementProgress();
            }
        }
    }
