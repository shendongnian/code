    private Form1 frm_1;
    public Form2(Form1 frm)
    {
        InitializeComponent();
        frm_1 = frm;
    }
    private void dataGridView1_CellDoubleClick(object sender,DataGridViewCellEventArgs e)
    {
       string name =  dataGridView1.CurrentRow.Cells["clmName"].Value.ToString();
       frm_1.txtCustomer.Text = name;
       this.close();
     }
