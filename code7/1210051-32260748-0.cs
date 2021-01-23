    public partial class frmPatientsNameDuplicated : Form
    {
    PatientFiles frmPatientsFiles = Application.OpenForms["PatientFiles"] as PatientFiles;
    public frmPatientsNameDuplicated()
    {
        InitializeComponent();
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
       this.Close();
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
       frmPatientsFiles.txtFileNum.Text = this.dgvPatientsName.CurrentRow.Cells[0].Value.ToString();
       frmPatientsFiles.txtArbName.Text = this.dgvPatientsName.CurrentRow.Cells[1].Value.ToString();
       frmPatientsFiles.txtEngName.Text = this.dgvPatientsName.CurrentRow.Cells[2].Value.ToString();
       this.Close();
    }
    }
