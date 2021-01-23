    private void importComandaToolStripMenuItem_Click(object sender, EventArgs e)
             {
                string cale = Application.StartupPath;
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    cale = ofd.FileName;
                    System.IO.StreamReader sr = new System.IO.StreamReader(cale);
                    string linie = null;
                    while ((linie = sr.ReadLine()) != null)
                    {
                            string comanda = sr.ReadLine();
                            string[] vcmd = comanda.Split(' ');
    
                            //foreach (string cmd in vcmd)
                            //{
                                 SqlConnection conn = new SqlConnection("server=localhost;" +
        "Trusted_Connection=yes;" +
        "database=erp; " +
        "connection timeout=30");
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "Insert into [erp].[dbo].[Comenzi] values("+vcmd[0]+","+vcmd[1]+",'"+vcmd[2]+"','"+vcmd[3]+"');";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = conn;
                    conn.Open();
                    cmd1.ExecuteNonQuery();
                    conn.Close();
    
                            //}
    
                        }
                    MessageBox.Show("Comanda inserata");
    
                    }
    
                else
                    MessageBox.Show("Inserare e?uata");
                }
            }
