    public class ViewModel : BindableBase
    {
        public ViewModel()
        {
            _showWindowCommand = new DelegateCommand(ShowWindow);
            _interactionRequest = new InteractionRequest<Confirmation>();
        }
        private readonly DelegateCommand _showWindowCommand;
        private InteractionRequest<Confirmation> _interactionRequest;
        public ICommand ShowWindowCommand
        {
            get { return _showWindowCommand; }
        }
        public IInteractionRequest InteractionRequest
        {
            get { return _interactionRequest; }
        }
        private void ShowWindow()
        {
            _interactionRequest.Raise(
                new Confirmation(),
                OnWindowClosed);
        }
        private void OnWindowClosed(Confirmation confirmation)
        {
            if (confirmation.Confirmed)
            {
                //perform the confirmed action...
            }
            else
            {
            }
        }
    }
