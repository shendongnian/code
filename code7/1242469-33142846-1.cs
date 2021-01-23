      protected void ddlChangeType_SelectedIndexChanged(object sender, EventArgs e)
            {
                DropDownList ddlChangeType = (DropDownList)sender;
                GridViewRow currentRow = (GridViewRow)ddlChangeType.NamingContainer;
                DropDownList ddlChangeSubType = currentRow.FindControl("ddlChangeSubType") as DropDownList;
    
                object objControl;
    
                if (ddlChangeSubType != null && currentRow != null && ddlChangeType != null)
                {
                    ddlChangeSubType.DataTextField = "Desc";
                    ddlChangeSubType.DataValueField = "ID";
                    ddlChangeSubType.DataSource = setChangeSubType(ddlChangeType.SelectedValue);
                    ddlChangeSubType.DataBind();
    
                    if (Session["DynamicControls"] != null)
                    {
                        for (int y = 0; y < CRFormGridView.Rows.Count; y++)
                        {
                            if (((Dictionary<int, object>)Session["DynamicControls"]).TryGetValue(y, out objControl))
                            {
                                if (currentRow.RowIndex == y)
                                    objControlsDict.Remove(y);
                                else
                                    objControlsDict.Add(y, objControl);
                            }
                        }
                    }
                    Session.Add("DynamicControls", objControlsDict);
                }
    
            }
    
            protected void ddlChangeSubType_SelectedIndexChanged(object sender, EventArgs e)
            {
                DropDownList ddlChangeSubType = (DropDownList)sender;
                GridViewRow currentRow = (GridViewRow)ddlChangeSubType.NamingContainer;
                DropDownList ddlChangeType = currentRow.FindControl("ddlChangeType") as DropDownList;
                //TextBox txt = currentRow.FindControl("txt") as TextBox;
    
                PlaceHolder placehldr = currentRow.FindControl("placehldrDynamicCnrtl") as PlaceHolder;
    
                object objControl;
    
                rowIndex = currentRow.RowIndex;
                if (Session["DynamicControls"] != null)
                {
                    for (int y = 0; y < CRFormGridView.Rows.Count; y++)
                    {
                        if (((Dictionary<int, object>)Session["DynamicControls"]).TryGetValue(y, out objControl))
                        {
                            objControlsDict.Add(y, objControl);
                        }
                    }
                }
    
                if (ddlChangeSubType != null && currentRow != null && ddlChangeSubType != null)
                {
                    switch (ddlChangeType.SelectedItem.Text.ToUpper())
                    {
                        case "UPDATE OFFER":
                            TextBox txtBox = new TextBox();
                            txtBox.Text = "Text Box Added";
                            txtBox.ID = "txt";
                            txtBox.ClientIDMode = ClientIDMode.Static;
                            txtBox.EnableViewState = true;
                            placehldr.Controls.Add(txtBox);
                            if (objControlsDict.ContainsKey(rowIndex))
                                objControlsDict.Remove(rowIndex);
                            objControlsDict.Add(rowIndex, txtBox);
                            break;
    
                        case "ADD COMPONENT":
                            Label lbl = new Label();
                            lbl.Text = "Label Added";
                            lbl.ID = "lbl";
                            lbl.ClientIDMode = ClientIDMode.Static;
                            lbl.EnableViewState = true;
                            placehldr.Controls.Add(lbl);
                            if (objControlsDict.ContainsKey(rowIndex))
                                objControlsDict.Remove(rowIndex);
                            objControlsDict.Add(rowIndex, lbl);
                            break;
    
                        case "UPDATE REQUEST":
                            break;
    
                        default:
                            break;
                    }
    
                    Session.Add("DynamicControls", objControlsDict);
                }
            }
     protected void placehldrDynamicCnrtl_PreRender(object sender, EventArgs e)
            {
                try
                {
                    if (Page.IsPostBack)
                    {
                        PlaceHolder placeHldr = (PlaceHolder)sender;
                        GridViewRow currentRow = (GridViewRow)placeHldr.NamingContainer;
    
                        objControlsDict = (Dictionary<int, object>)Session["DynamicControls"];
                        if (objControlsDict != null)
                        {
                            if (objControlsDict.ContainsKey(count) && objControlsDict[count] is TextBox)
                            {
                                TextBox txtBox = (TextBox)objControlsDict[count];
                                txtBox.Text = "Text Box Added";
                                txtBox.ID = "txt";
                                txtBox.ClientIDMode = ClientIDMode.Static;
                                txtBox.EnableViewState = true;
                                ((PlaceHolder)this.CRFormGridView.Rows[count].Cells[3].FindControl(
                                    "placehldrDynamicCnrtl")).Controls.Add(txtBox);
                            }
    
                            if (objControlsDict.ContainsKey(count) && objControlsDict[count] is Label)
                            {
                                Label lbl = (Label)objControlsDict[count];
                                lbl.Text = "Label Added";
                                lbl.ID = "lbl";
                                lbl.ClientIDMode = ClientIDMode.Static;
                                lbl.EnableViewState = true;
                                ((PlaceHolder)this.CRFormGridView.Rows[count].Cells[3].FindControl(
                                    "placehldrDynamicCnrtl")).Controls.Add(lbl);
                            }
                            count++;
                        }
                    }
                }
                catch (Exception es)
                {
                    throw;
                }
            }
