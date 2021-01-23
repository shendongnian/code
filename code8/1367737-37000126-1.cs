    public class ViewModel2 : ViewModelBase
    {
        public ViewModel2()
        {
            Messenger.Default.Register<Vm1toVm2Message>(this, HandleVm1toVm2Message);
        }
        private void HandleVm1toVm2Message(Vm1toVm2Message msg)
        {
            // Do what you want here
        }
    }
