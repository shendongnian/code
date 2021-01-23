    public void createTxtTeamNames(int id)
    {
        for (int i = 0; i < id; ++i)  
        {
            TextBox txt = new TextBox();
            string name = "TeamNumber" + i.ToString();
            txt.Name = name;
            txt.Text = name;
            txt.Location = new Point(0, 32 + (i * 28));
            txt.Visible = true;
            this.Controls.Add(txt);
        }
    }
