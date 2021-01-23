     <DataGrid FontSize="16" x:Name="List" AutoGenerateColumns="False" CanUserResizeColumns="False" SelectedIndex="1">
            <DataGrid.Columns>
                <DataGridTextColumn FontSize="14" Header="Name" Width="150" Binding="{Binding Name}"/>
                <DataGridTextColumn FontSize="14" Header="Mobile No." Width="170" Binding="{Binding MobileNo}"/>
                <DataGridTextColumn FontSize="14" Header="Email" Width="200" Binding="{Binding Email}"/>
                <DataGridTextColumn FontSize="14" Header="Address" Width="240" Binding="{Binding Address}"/>
            </DataGrid.Columns>
        </DataGrid>
    public class ContactsViewModel : Screen 
    {
        public ContactsViewModel()
        {
            string str = File.ReadAllText("Contacts.txt");
            string[] strContracts = str.Split(',');
            foreach (var item in strContracts)
            {
                string[] fields = item.Trim().Split(' ');
                _list.Add(new Contact() { Name = fields[0],MobileNo= fields[1],Email=fields[2],Address=fields[3] });
            }
        }
        private IObservableCollection<Contact> _list = new BindableCollection<Contact>();
        public IObservableCollection<Contact> List
        {
            get { return _list; }
            set
            {
                _list = value;
                NotifyOfPropertyChange(() => List);
            }
        }
    }
    public class Contact
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string mobileNo;
        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }
    }
