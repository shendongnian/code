            List<dynamic> lstName = new List<dynamic>();
            List<dynamic> lstCMSID = new List<dynamic>();
            List<dynamic> lstSpecialtyPhys = new List<dynamic>();
            lstName.Add("John Doe");
            lstCMSID.Add("56");
            lstSpecialtyPhys.Add("90");
            lstName.Add("James Coon");
            lstCMSID.Add("34");
            lstSpecialtyPhys.Add("24");
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Number");
            dt.Columns.Add("Value");
            for (int i = 0; i < lstName.Count; i++)
            {
                dt.Rows.Add(lstName[i], lstCMSID[i], lstSpecialtyPhys[i]);
            }
            gvSP.DataSource = dt;
            gvSP.DataBind();
