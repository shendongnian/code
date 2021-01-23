            //Making all columns in GridView visible to rebind the data 
            //Otherwise DataBind() will not work as there is checking at ActiveStatus[].
            for (int i = 0; i < 11; i++)
                grdOrgListData.Columns[i].Visible = true;
            grdOrgListData.DataSource = ds;
            grdOrgListData.DataBind();
            grdOrgListData.Columns[0].Visible = false;
            grdOrgListData.Columns[2].Visible = false;
            grdOrgListData.Columns[3].Visible = false;
            grdOrgListData.Columns[4].Visible = false;
            grdOrgListData.Columns[7].Visible = false;
            grdOrgListData.Columns[9].Visible = false;
            grdOrgListData.Columns[10].Visible = false;
