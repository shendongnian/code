      private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.Value.ToString().Equals("X"))
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
        }
