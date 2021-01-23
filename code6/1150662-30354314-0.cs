        String Grade = "A";
        string[] GradeLevels = new string[] { "A", "B", "C" };
        DropDownList _ddl = new DropDownList();
        _ddl.AutoPostBack=true;
        for (int i = 0; i < GradeLevels.Length; i++)
        {
            _ddl.Items.Add(new ListItem(GradeLevels[i], GradeLevels[i]));
        }
            _ddl.Items.FindByValue(Grade).Selected = true;
        PlaceHolder1.Controls.Add(_ddl);
