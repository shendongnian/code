         private void tab1_SelectedIndexChanged(object sender, EventArgs e)
            {
                 if ( reading==true &&  tabControl1.SelectedTab == tabControl1.TabPages["tabname2"])//your specific tabname
                 {
                      System.Windows.Forms.MessageBox.Show("You cannot export while reading. Please stop before exporting");
                      tabControl1.SelectedTab = tabControl1.TabPages["tabname2"];
                    //To return to the previous tab if reading has not processing
            
                 }
            }
