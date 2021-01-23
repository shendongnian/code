    string Select = "SELECT * FROM tblReject_test";
    string Department = txtDepartment.Text;
    string Start_Date = txtStart.Text;
    string End_Date = txtEnd.Text;
    string Anatomy = txtAnatomy.Text;
    string RFR = cmbRFR.Text;
    string Comment = txtComment.Text;
    List<string> parameters = new List<string>();
    bool first = true;
    
    if (Department != "")
        parameters.Add("department_id =" + "'" + Department + "'");
                
    if (Anatomy != "")
        parameters.Add("body_part_examined =" + "'" + Anatomy + "'");
                
    if (Start_Date != "")
        parameters.Add("study_date =" + "'" + Start_Date + "'");
                
    if (End_Date != "")
        parameters.Add("study_date =" + "'" + End_Date + "'");
                
    if (RFR != "")
        parameters.Add("reject_category =" + "'" + RFR + "'");
    
    if (Comment != "")
        parameters.Add("reject_comment =" + "'" + Comment + "'");
    
    if (parameters.Count == 0)
        Select = "SELECT * FROM tblReject_test";
    
    for (int i = 0; i < parameters.Count(); i++)
    { 
        if(i == 0)
            Select += " WHERE ";
        else
            Select += " AND ";
        Select += parameters[i];
    }
