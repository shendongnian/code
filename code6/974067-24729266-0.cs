    string _SQL = "Select UserTypeId,UserTypeName From UserTypes Order By UserTypeName";
    //Dont include Order By UserTypeName if you have created clustered index on it.
    
    SqlDataAdapter Da = New SqlDataAdapter(_SQL, Connection);
    DataTable Dt = New DataTable();
    Da.Fill(Dt);
    
    DataGridViewComboBoxColumn colUserTypeId = (DataGridViewComboBoxColumn)DataGridView1.Columns["UserTypeId"];
    
    colUserTypeId.DisplayMember = "UserTypeName";
    colUserTypeId.ValueMember = "UserTypeId";
    
    colUserTypeId.DataSource = Dt;
    
    //CODE TO FILL GRIDVIEW
