    List<Project> listPrj = new List<Project>();
     if (obds.Tables.Count > 0 && obds.Tables[0].Rows.Count > 0)
     {
            for (int iCount = 0; iCount < obds.Tables[0].Rows.Count; iCount++)
            {
                listPrj.Add(new Project(int.Parse(obds.Tables[0].Rows[iCount]["Project_ID"].ToString()), obds.Tables[0].Rows[iCount]["Project_Name"].ToString());
            }    
     }
	cmbProjectName.DisplayMember = Name;
	cmbProjectName.ValueMember = ID;
	cmbProjectName.DataSource = listPrj;
