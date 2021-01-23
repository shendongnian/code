    private void cmdShow_Click(object sender, EventArgs e)
        {
            string m = "";
            foreach (DataGridViewRow row in dg1.Rows)    // error    "System.NullReferenceException" on dt.Rows
            {
                m = m + row.Cells[0].Value + " " + row.Cells[1].Value + "\n";
            }
            MessageBox.Show(m);
         }
