    var combocolumnA = new DataGridViewComboBoxColumn();
            combocolumnA.HeaderText = "ID"; // grid header name
            combocolumnA.ValueMember = "id";// database Column name
            combocolumnA.DataSource = details;
            GV.Columns.Add(combocolumnA);
            combocolumnA.Width = 100;
    
            var combocolumnB = new DataGridViewComboBoxColumn();
            combocolumnB.HeaderText = "Name";
            combocolumnB.ValueMember = "Name";
            combocolumnB.DataSource = details;
            GV.Columns.Add(combocolumnB);
            combocolumnB.Width = 150;
