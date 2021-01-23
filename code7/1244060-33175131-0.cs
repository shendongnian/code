    public Form1() {
      InitializeComponent();
      DataTable dt = new DataTable();
      dt.Columns.Add("C1");
      DataRow dr1 = dt.NewRow();
      dr1[0] = "ccc";
      dt.Rows.Add(dr1);
      DataRow dr2 = dt.NewRow();
      dr2[0] = "xxx";
      dt.Rows.Add(dr2);
      dgv.AutoGenerateColumns = false;
      var dgvCB = new DataGridViewComboBoxColumn();
      dgvCB.Items.AddRange(new string[] { "aaa", "bbb", "ccc", "ddd" });
      dgv.Columns.Add(dgvCB);
      dgv.Columns[0].DataPropertyName = "C1";
      dgv.DataError += dgv_DataError;
      dgv.DataSource = dt;
    }
    void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      if (e.ColumnIndex == 0) {
        string value = dt.Rows[e.RowIndex][e.ColumnIndex].ToString();
        var dgvCB = (DataGridViewComboBoxCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if (!dgvCB.Items.Contains(value)) {
          dgvCB.Items.Add(value);
        }
      }
    }
