    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            LockKeys();
        }
        private void LockKeys()
        {
            if(CurrentUser.AccessLevel == 1)
            {
                //Enable/Disable Controls
            }
            else if (CurrentUser.AccessLevel == 2)
            {
                //Enable/Disable Controls
            }
            else if (CurrentUser.AccessLevel == 3)
            {
                //Enable/Disable Controls
            }
            else if (CurrentUser.AccessLevel == 4)
            {
                //Enable/Disable Controls
            }
        }
    }
