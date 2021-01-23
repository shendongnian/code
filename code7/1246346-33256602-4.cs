        public class ButtonLogicViewmodel:BaseObservableObject
    {
        private bool _wasPressedAtOnse;
        private ICommand _pressCommand;
        public ButtonLogicViewmodel()
        {
            WasPressedAtOnse = false;
        }
        public ICommand PressCommand
        {
            get { return _pressCommand ?? (_pressCommand = new RelayCommand(OnPress)); }
        }
        private void OnPress()
        {
            WasPressedAtOnse = !WasPressedAtOnse;
        }
        public bool WasPressedAtOnse
        {
            get { return _wasPressedAtOnse; }
            set
            {
                _wasPressedAtOnse = value;
                OnPropertyChanged();
            }
        }}
