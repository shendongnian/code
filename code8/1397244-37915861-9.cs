    if (ddl2.SelectedIndex == 1)
    {
        if (ddl3.SelectedItem.Text == "True")
        {
            query = "select M.name,M.ID,M.count,u.ID,sName from tblrecord Mts,data u,Type si where " +
             "u.name='" + ddl1.SelectedValue + "' and mts.name=u.id and si.ID= Mts.ID ";
        }
        else if (ddl3.SelectedItem.Text == "False")
        {
            query = "select M.name,M.ID,M.count,u.ID,sName from tblrecord Mts,data u,Type si where " +
             "u.name='" + ddl1.SelectedValue + "' and mts.name=u.id and si.ID= Mts.ID ";
        }
    else 
        {
           query = "select M.name,M.ID,M.count,u.ID,sName from tblrecord Mts,data u,Type si where " +
             "u.name='" + ddl1.SelectedValue + "' and mts.name=u.id and si.ID= Mts.ID ";
        }
     }
    else
    {
        if (ddl3.SelectedItem.Text == "True")
        {
            query = "select M.name,M.ID,M.count,u.ID,sName from tblrecord Mts,data u,Type si where " +
             "u.name='" + ddl1.SelectedValue + "' and mts.name=u.id and si.ID= Mts.ID ";
        }
        else if (ddl3.SelectedItem.Text == "False")
        {
            query = "select M.name,M.ID,M.count,u.ID,sName from tblrecord Mts,data u,Type si where " +
             "u.name='" + ddl1.SelectedValue + "' and mts.name=u.id and si.ID= Mts.ID ";
         }
     else
        {
           query = "select M.name,M.ID,M.count,u.ID,sName from tblrecord Mts,data u,Type si where " +
             "u.name='" + ddl1.SelectedValue + "' and mts.name=u.id and si.ID= Mts.ID ";
         }
    }
