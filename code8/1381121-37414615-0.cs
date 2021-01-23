    private void GetControls()
            {
                count++;
                for (int i = 10; i < 12; i++)
                {
                    for (int j = 0; j < 60; j += 15)
                    {
                        Button btn = new Button();
                        btn.Text = i + "-" + j;
                        btn.ID = i + "-" + j;
                        btn.Command += new CommandEventHandler(this.btn_Click);
                        // btn.Click += btn_Click;
                        flag = true;
                        btn.CommandName = i + "-" + j;
                        if (count == 1)
                        {
                            PlaceHolder1.Controls.Add(btn);
                            List<string> createdControls = Session["Controls"] != null ? Session["Controls"] as List<string> : new List<string>();
                            if (!createdControls.Contains(btn.ID)) createdControls.Add(btn.ID);
                            Session["Controls"] = createdControls;
                        }
                    }
                }
    
            }
