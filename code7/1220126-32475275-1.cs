    try
                {
                    this.MaximizeBox = false;
                    this.MinimizeBox = false;
                    this.BackColor = Color.White;
                    this.ForeColor = Color.Black;
                    this.Size = new System.Drawing.Size(550, 550);
                    this.Text = "Test Create form in run time ";
                   if (ControlText == "button")
                      {
                        this.btnAdd.BackColor = Color.Gray;
                        this.btnAdd.Text = "Add";
                        this.btnAdd.Location = new System.Drawing.Point(90, 25);
                        this.btnAdd.Size = new System.Drawing.Size(50, 25);
                        this.Controls.Add(btn);
                    }
    }
