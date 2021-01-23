    public class AvigilonViewModel : ViewModelBase
    {
        public AvigilonViewModel()
        {
            Messenger.Default.Register<CleanUp>(this,CallCleanUp);
        }
        private void CallCleanUp()
        {
    	    //do the actual cleaning up here
            Cleanup();
        }
    }
