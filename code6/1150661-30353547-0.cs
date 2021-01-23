        Dropdownlist[] _ddl = new Dropdownlist[6];
        
        for(int i = 0; i < 6; i++)
        {
            _dll[i] = new Dropdownlist();
            _dll[i].ID = "dropdown" + i;
            _ddl[i].AutoPostBack = true;
            _ddl[i].Items.AddRange(GradeLevels);       
        }
        
        // set the selected item in the first list
        if (Grade == "A")
            _ddl[0].Items.FindByValue("A").Selected = true;
