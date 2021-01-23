    `rd.AutoSize = false;
    DataGridView dgv = new DataGridView();
    dgv.Columns.Add("column1", "id");
    dgv.Columns.Add("column2", "name");
    dgv.Rows.Add(1, "Anusha");
    dgv.Rows.Add(2, "Anu");
    dgv.Left = 20;          // adding the left margin
    rd.Controls.Add(dgv);
    rd.Height = dgv.Height;
    rd.Width = dgv.Width + 20;  //adding same margin to the radio button width`
