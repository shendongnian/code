    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        POS POS = null;
        FormCollection fc = Application.OpenForms;
        foreach (Form frm in fc)
        {
            if (frm.GetType().Name.Equals("POS"))
            {
                POS = frm as POS;
            }
        }
        if (POS == null)
        {
            POS = new POS();
        }
        string ProductCode = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        string ProductName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        
        POS.FillTextBoxes(ProductCode, ProductName);
        POS.Show();
    }
