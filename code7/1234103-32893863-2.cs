    Dg_UserList.AutoGenerateColumns = false;
    DataGridViewTextBoxColumn userCol = new DataGridViewTextBoxColumn();
    DataGridViewButtonColumn emailCol = new DataGridViewButtonColumn();
    DataGridViewButtonColumn tagCol = new DataGridViewButtonColumn();
    DataGridViewButtonColumn xuidCol = new DataGridViewButtonColumn();
    DataGridViewTextBoxColumn signCol = new DataGridViewTextBoxColumn();
    DataGridViewTextBoxColumn autoCol = new DataGridViewTextBoxColumn();
    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
    userCol.Name = "UserID";                    // Allows access to columns or
    emailCol.Name = "EmailAddress";             // cells in the following manner:
    tagCol.Name = "Gamertag";                   // dgv.Rows[index].Cells["Name"];
    xuidCol.Name = "Xuid";
    signCol.Name = "SignedIn";
    autoCol.Name = "AutoSignin";
    picCol.Name = "Gamerpic";
    userCol.DataPropertyName = "UserID";        // MUST match DataSource properties.
    emailCol.DataPropertyName = "EmailAddress"; // Allows DataSourced columns to match
    tagCol.DataPropertyName = "Gamertag";       // up with manually created columns.
    xuidCol.DataPropertyName = "Xuid";
    signCol.DataPropertyName = "SignedIn";
    autoCol.DataPropertyName = "AutoSignin";
    picCol.DataPropertyName = "Gamerpic";
    userCol.HeaderText = "User ID";             // Allows displaying different text
    emailCol.HeaderText = "Email Address";      // for the column headers.
    tagCol.HeaderText = "Gamer Tag";
    xuidCol.HeaderText = "Xuid";
    signCol.HeaderText = "Signed In";
    autoCol.HeaderText = "Auto Sign in";
    picCol.HeaderText = "Avatar";
    Dg_UserList.Columns.Add(userCol);
    Dg_UserList.Columns.Add(emailCol);
    Dg_UserList.Columns.Add(tagCol);
    Dg_UserList.Columns.Add(xuidCol);
    Dg_UserList.Columns.Add(signCol);
    Dg_UserList.Columns.Add(autoCol);
    Dg_UserList.Columns.Add(picCol);
