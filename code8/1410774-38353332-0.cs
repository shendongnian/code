    foreach (DataGridViewRow dr in dataGridView1.Rows)
        {
            foreach (DataGridViewColumn column in dgv1)
            {
                double val;
                if (double.TryParse(dr.Cells[column.Name].Value.ToString(), out val))
                {
                    sw.Write(string.Format(System.Globalization.CultureInfo.GetCultureInfo("de-DE"), "{0:0.00}", val));
                    sw.Write(";");
                }
            }
        }
