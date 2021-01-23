            //Control create button   
              private void button1_Click(object sender, EventArgs e)
                        {
                            
                            Panel pnl = new Panel();
                            pnl.Name = "pnltest";
                            pnl.Location = new Point(500, 200);
                            TextBox txt1 = new TextBox();
                            txt1.Name = "txttest";
                            txt1.Location = new Point(0 ,10);
                            pnl.Controls.Add(txt1);
                            ComboBox cmb = new ComboBox();
                            cmb.Location = new Point(0, 50);
                            cmb.Name = "cmbtest";
                            cmb.Items.Add("one");
                            cmb.Items.Add("two");
                            cmb.Items.Add("three");
                            pnl.Controls.Add(cmb);
                            Button btn = new Button();
                            btn.Name = "btntest";
                            btn.Text = "submit";
                            btn.Location = new Point(0, 75);
                            btn.Click += btn_Click;
                            pnl.Controls.Add(btn);
                            this.Controls.Add(pnl);
                
                
                        }
    //control button click event
         void btn_Click(object sender, EventArgs e)
                {
                    foreach (Control frmcntrl in this.Controls)
                    {
                        if (frmcntrl is Panel)
                        {
                            if (frmcntrl.Name == "pnltest")
                            {
                                foreach (Control item in frmcntrl.Controls)
                                {
                                    if (item is TextBox)
                                    {
                                        if (item.Name == "txttest")
                                        {
                                            MessageBox.Show(item.Text .ToString());
                                        }
                                    }
                                    else if (item is ComboBox)
                                    {
                                        if (item.Name == "cmbtest")
                                        {
                                            MessageBox.Show(item.Text);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
