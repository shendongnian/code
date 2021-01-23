    string strExp = "";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    strExp = "RAName = '" + ds.Tables[0].Rows[i]["RAName"].ToString() + "'";
                    DataRow[]  dr=  ds.Tables[0].Select(strExp);
                }
                ds.Tables[0].AcceptChanges(); //Commits all the changes made to this table since the last time AcceptChanges was called.
                DataTable dtNew = ds.Tables[0].Select(strExp).CopyToDataTable();
