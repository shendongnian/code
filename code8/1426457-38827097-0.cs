    <asp:DropDownList ID="drp_district" runat="server" EnableViewState="true" OnSelectedIndexChanged="drp_district_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" autocomplete="off"></asp:DropDownList>
    
       protected void drp_district_SelectedIndexChanged(object sender, EventArgs e)
            {
                string value = drp_district.SelectedValue;
               
                _objdll.TableName = "tbl_assemblydetails";
                _objdll.Condition = "district_id";
                _objdll.Value = value;
    
                DataSet ds_assembly = _objdal.Fn_GEN_SelectAll_1Condition(strcommoncon, _objdll);
                if (ds_assembly.Tables[0].Rows.Count > 0)
                {
                    drp_assembly.DataTextField = "assembly_english".ToUpper();
                    drp_assembly.DataValueField = "assembly_id";
                    drp_assembly.DataSource = ds_assembly;
                    drp_assembly.DataBind();
                }
                else
                {
                    drp_assembly.DataSource = null;
                    drp_assembly.DataBind();
                    drp_assembly.Items.Insert(0, new ListItem("Select Assembly", "0"));
                }
        }
