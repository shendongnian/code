     private void btnSave_Click(object sender, EventArgs e)
                {
                    x = 4;
                     y = panel1 .Controls.Count * 70;
                    Button newButton = new Button ();
                    newButton.Height = 150;
                    newButton.Width = 60;
                    newButton.Location = new Point(x, y);
                    newButton.Text= "your text";
                     newButton.Click += new       
                  System.EventHandler(Button_Click);             
                  tabControl1.TabPages [0].Controls.Add(newButton);
    
            }
