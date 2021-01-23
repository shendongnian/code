        public partial class OutlookContacts : Form
            {
                private BindingSource supplierDataBindingSource = new BindingSource();
        
                public static IEnumerable<Employees> displayListOfOutLookUsers = new List<Employees>();
                public OutlookContacts()
                {
                    InitializeComponent();
                    dataGridView1.DataSource = supplierDataBindingSource;
                    displayListOfOutLookUsers = EnumerateGAL();
        
                }
                private IEnumerable<Employees> EnumerateGAL()
                {
                    Outlook.Application ol = new Outlook.ApplicationClass();
    /*Outlook.AddressList gal = Application.Session.GetGlobalAddressList(); won't work because '_Application' needs to be instantiated using an object before using. */
                    Outlook.AddressList gal = ol.Session.GetGlobalAddressList();
    /*Declaring a list emp of type Employees.*/
                List<Employees> emp = new List<Employees>();
                if (gal != null)
                {
                    for (int i = 1;
                        i <= Math.Min(100, gal.AddressEntries.Count - 1); i++)
                    {
                        Outlook.AddressEntry addrEntry = gal.AddressEntries[i];
                        if (addrEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry
                            || addrEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
                        {
                            Outlook.ExchangeUser exchUser =addrEntry.GetExchangeUser();
    
    /*Storing fetched records in the list.*/
                            emp.Add(new Employees {EmployeeName = exchUser.Name,EmployeeEmail = exchUser.PrimarySmtpAddress});
                            
                        }
                        if (addrEntry.AddressEntryUserType == Outlook.OlAddressEntryUserType.olExchangeDistributionListAddressEntry)
                        {
                            Outlook.ExchangeDistributionList exchDL = addrEntry.GetExchangeDistributionList();
                            
                        }
                    }
                }
                displayListOfOutLookUsers = emp;
                supplierDataBindingSource.DataSource = displayListOfOutLookUsers.Select(l => new { l.EmployeeName, l.EmployeeEmail });
                dataGridView1.AutoResizeColumns(
                        DataGridViewAutoSizeColumnsMode.DisplayedCells);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                int j = 0;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    c.SortMode = DataGridViewColumnSortMode.Automatic;
                    j += c.Width;
                }
                dataGridView1.Width = j + dataGridView1.RowHeadersWidth + 232;
                this.Width = dataGridView1.Width + 40;
                return displayListOfOutLookUsers;
            }
