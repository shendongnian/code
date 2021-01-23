    protected override void OnInit(EventArgs e)
            {
                TextBox t = new TextBox();
                t.ID = "t01";
                t.TextChanged += t_TextChanged;
                t.AutoPostBack = true;
                Panel1.Controls.Add(t);
            }
    
          protected  void t_TextChanged(object sender, EventArgs e)
            {
                
            }
