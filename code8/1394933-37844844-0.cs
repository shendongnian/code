    public class PersonInput : Window
    {
        public void PersonInput()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
        //  initializer can be null to create a new Person, or you can pass in an 
        //  existing Person to edit it. Note that we return an edited *copy*, instead of 
        //  editing the original. Thus you can check to see if anything was actually 
        //  changed, you can easily support an Undo feature, etc. etc. 
        public static Person ShowDialog(Person initializer)
        {
            var vm = new PersonViewModel(initializer);
            var dlg = new PersonInput() { DataContext = vm };
            //  ShowDialog() shows dialog *modally*, disabling the parent window
            //  It returns Nullable<bool>.
            if (dlg.ShowDialog().GetValueOrDefault(false))
            {
                return vm.ToPerson();
            }
            return null;
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
