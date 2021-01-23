                        try
                        {
                        
                        foreach (DataGridViewRow r in DataGridView1.Rows)
                        {
                            if (r != null)
                            {
                                if (String.Compare(r.Cells[0].Value.ToString(), TextBox1.Text) == 0)
                                {
                                    r.Selected = true;
                                    TextBox1.Text = r.Cells[2].Value.ToString();
                                }
                                }
                            }
                        }
                        catch(Exception ex) 
                        {
                            MessageBox.Show(ex.ToString());
                        }
