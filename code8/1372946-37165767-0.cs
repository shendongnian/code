     private void btnSave_Click(object sender, EventArgs e)
                {
                    Button newButton = new Button ();
                    newButton.Height = 150;
                    newButton.Width = 60;
                    newButton.Text= "your text";
                     newButton.Click += new       
                  System.EventHandler(Button_Click);             
                  tabControl1.TabPages [0].Controls.Add(newButton);
    
            }
