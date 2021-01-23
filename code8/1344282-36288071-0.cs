	public interface IResource
	{
	}
    public abstract class Worker
    {
        private class TheResource : IResource
        {
            // implement
        }
        public void DoWork()
        {
            Prepare();
            var resObj = new TheResource();
            Work(resObj);
            // if needed, cleanup/dispose resObj here
            Cleanup();
        }
        protected abstract void Work(IResource resourceObj);
    }
