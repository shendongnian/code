    public abstract class MyTemplateClass : IMyCommand
    {
        public void Execute()
        {
             MyProcessFirst();
             MyProcessSecond();
        }
    
        protected abstract void MyProcessFirst();
        protected abstract void MyProcessSecond();
    }
