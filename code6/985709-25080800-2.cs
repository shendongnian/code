        public class ButtonDescription
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private ICommand onClickCommand;
        public ICommand OnClickCommand
        {
            get { return onClickCommand; }
            set { onClickCommand = value; }
        }
        public ButtonDescription()
        {
        }
    }
