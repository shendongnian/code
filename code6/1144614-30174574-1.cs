        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if(e.ColumnIndex == dgv.Columns["Bio"].Index)
            {
                string bioSelected = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                switch (bioSelected)
                {
                    case "Bio1":
                        BioRB1.IsChecked = true;
                        break;
                    case "Bio2":
                        BioRB2.IsChecked = true;
                        break;
                    case "Bio3":
                        BioRB3.IsChecked = true;
                        break;
                    default:
                        Console.WriteLine("Default case...this is optional");
                        break;
                }
            }
        }
