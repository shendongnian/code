            DataTable cTable = null;
            DataSet Company = WebSerivce.Company(IP, DataBaseName, UserName, Password);
            if (Company != null && Company.Tables[0] != null)
                cTable = Company.Tables[0];
            if (!Page.IsPostBack)
            {
                if(cTable.Rows.Count > 0)
                {
                    DropDownList1.DataSource = cTable;
                    DropDownList1.DataValueField = "ID_Comp";
                    DropDownList1.DataTextField = "Comp_Name";
                    DropDownList1.DataBind();
                }
                else
                {
                    DropDownList1.DataSource = new DataTable();
                    DropDownList1.DataBind();
                    DropDownList1.Items.Insert(0, "Select");
                }
                
            
            } 
