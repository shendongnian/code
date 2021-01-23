    private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem != null &&
               comboBox2.SelectedItem != null &&
               numericUpDown1.Value != 0 &&
               numericUpDown2.Value != 0 &&
               numericUpDown3.Value != 0 &&
               numericUpDown4.Value != 0)
               {
                  string domacin = comboBox1.GetItemText(comboBox1.SelectedItem);
                                    int D_kosevaPrvoPoluvreme = (int)numericUpDown1.Value;
                                    int D_kosevaDrugoPoluvreme = (int)numericUpDown3.Value;
                                    int D_ukupnoKoseva = D_kosevaDrugoPoluvreme + D_kosevaPrvoPoluvreme;
                                    int D_primljenihKosevaPrvoPoluvreme = (int)numericUpDown2.Value;
                                    int D_primljenihKosevaDrugoPoluvreme = (int)numericUpDown4.Value;
                                    int D_ukupnoPrimljenihKoseva = D_primljenihKosevaDrugoPoluvreme + D_primljenihKosevaPrvoPoluvreme;
    
                                    string gost = comboBox2.GetItemText(comboBox2.SelectedItem);
                                    int G_kosevaPrvoPoluvreme = (int)numericUpDown2.Value;
                                    int G_kosevaDrugoPoluvreme = (int)numericUpDown4.Value;
                                    int G_ukupnoKoseva = G_kosevaDrugoPoluvreme + G_kosevaPrvoPoluvreme;
                                    int G_primljenihKosevaPrvoPoluvreme = (int)numericUpDown1.Value;
                                    int G_primljenihKosevaDrugoPoluvreme = (int)numericUpDown3.Value;
                                    int G_ukupnoPrimljenihKoseva = G_primljenihKosevaDrugoPoluvreme + G_primljenihKosevaPrvoPoluvreme;
    
                                    int rezultat;
                                    Functions.odrediPobednika(out rezultat, D_ukupnoKoseva, G_ukupnoKoseva);
    
                                    //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arist\Documents\VisualStudio2015\Projects\NBA\NBA\NBA.mdf;Integrated Security=True");
                                    //SqlCommand cmd = new SqlCommand("", con);
        }
    }
