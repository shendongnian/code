     public partial class TestForm : Form
       {
         public TestForm()
        {
            InitializeComponent();
            ShowSelectFromListWidget();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ShowSelectFromListWidget()
        {
            var uc = new FindCustomerControl();
            uc.ItemHasBeenSelected += uc_ItemHasBeenSelected;
            this.MakeUserControlPrimaryWindow(uc);
        }
        void uc_ItemHasBeenSelected(object sender, FindCustomerControl.SelectedItemEventArgs e)
        {
            var value = e.SelectedChoice;
            lblCustomer.Text = value;
            lblMerchant.Focus();
             
            //ClosePrimaryUserControl();
        }
        private void MakeUserControlPrimaryWindow(UserControl uc)
        {
            // my example just puts in in a panel, but for you
            // put your special code here to handle your user control management 
            panel1.Controls.Add(uc);
        }
        private void ClosePrimaryUserControl()
        {
            // put your special code here to handle your user control management 
            panel1.Controls.Clear();
        }
}
