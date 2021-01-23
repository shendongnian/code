    if (rdr.HasRows)
            {
                while(rdr.Read())
                {
                    label5.Text = rdr[0] != DbNull.Value ? (rdr[0]).ToString() : string.Empty;
                    string lastregno = label5.Text;
                    string digits = lastregno.Substring(lastregno.Length - 4, 4);
                    label4.Text = digits.ToString();
                    int i = Convert.ToInt32(digits) + 1;
                    for (int max = 0; max < dataGridView1.Rows.Count; max++)
                    {
                        label4.Text = i.ToString("0000");
                        string concati = reg_no + label3.Text + label4.Text;
                        dataGridView1.Rows[max].Cells[2].Value = concati;
                        i++;
                    }
                }
            }
            
