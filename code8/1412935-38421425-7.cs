    public partial class RootForm : Form
    {
        private readonly IFormOpener formOpener;
        public RootForm(IFormOpener formOpener)
        {
            this.formOpener = formOpener;
            this.InitializeComponent();
        }
        private void ShowCustomers_Click(object sender, EventArgs e)
        {
            this.formOpener.ShowModelessForm<AllCustomersForm>();
        }
        private void EditCustomer_Click(object sender, EventArgs e)
        {
            var result = this.formOpener.ShowModalForm<EditCustomerForm>();
            // do something with result
        }
    }
