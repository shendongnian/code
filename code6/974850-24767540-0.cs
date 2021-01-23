    public partial class frmCategory : Form
    {
    public DataSet ds2;
    public frmCategory(DataSet dsMain)
    {
        ds2 = dsMain;
        InitializeComponent();
    }
    private void frmCategory_Load(object sender, EventArgs e)
    {
        dgvCategory.DataSource = ds2.Tables[0]; //you can use .Tables[1] or the desired table
        dgvCategory.DataMember = "Category";
        dgvCategory.Refresh();
    }
}
