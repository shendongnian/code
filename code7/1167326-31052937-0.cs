    //Create Button Dynamic Control
                 protected void btnDyCreateControl_Click(object sender, EventArgs e)
                        {
                           
                            try
                            {
                                int numberofparticipants = 5;
                                ViewState["numberofparticipants"] = numberofparticipants;
                                int test = (int)ViewState["numberofparticipants"];
                                int rowcount = 1;
                                int columnCount = numberofparticipants;
                                CreateDynamicTable(rowcount, columnCount);
                               
                                    
                            }
                            catch (Exception ex)
                            {
                
                
                            }
                        }
                     //submit values
                protected void btnSave_Click(object sender, EventArgs e)
                    {
                       try
                    {
                       
                        List<string> listParticipantName = new List<string>();
                        if (ViewState["numberofparticipants"] != null)
                        {
                            int numberofparticipants = Convert.ToInt32(ViewState["numberofparticipants"]);
            
                                foreach (Control c in panelNameofParticipants.Controls)
                                {   
                                   if (c is Table)
                                    {
                                        foreach (TableRow row in c.Controls)
                                        {
                                            int i = 0;
                                            foreach (TableCell cell in row.Controls)
                                            {
                                               
                                                if (cell.Controls[0] is TextBox)
                                                {
                                                    string findcontrol = "txtNameofParticipant" + i;
                                                    TextBox txtParticipantName = (TextBox)cell.Controls[0].FindControl(findcontrol);
                                                    listParticipantName.Add(txtParticipantName.Text);
                                                  
                                                }
                                                i++;
                                               
                                            }
                                            
                                            
                                        }
                                    }
                                }
                           
                        }
                    }
                    catch (Exception ex)
                    {
            
                    }
                    }
            
                  //Save ViewState
            protected override object SaveViewState()
                    {
                        object[] newViewState = new object[3];
            
                        List<string> txtValues = new List<string>();
                        foreach (Control c in panelNameofParticipants.Controls)
                        {
                            if (c is Table)
                            {
                                foreach (TableRow row in c.Controls)
                                {
                                    foreach (TableCell cell in row.Controls)
                                    {
                                        if (cell.Controls[0] is TextBox)
                                        {
                                            txtValues.Add(((TextBox)cell.Controls[0]).Text);
                                        }
                                    }
                                }
                            }
                        }
            
                        newViewState[0] = txtValues.ToArray();
                        newViewState[1] = base.SaveViewState();
                        if (ViewState["numberofparticipants"] != null)
                            newViewState[2] = (int)ViewState["numberofparticipants"];
                        else
                            newViewState[2] = 0;
                        return newViewState;
                    }
        //Load ViewState
        
        protected override void LoadViewState(object savedState)
                {
                    //if we can identify the custom view state as defined in the override for SaveViewState
                    if (savedState is object[] && ((object[])savedState).Length == 3 && ((object[])savedState)[0] is string[])
                    {
                        object[] newViewState = (object[])savedState;
                        string[] txtValues = (string[])(newViewState[0]);
                        if (txtValues.Length > 0)
                        {
                            //re-load tables
                            CreateDynamicTable(1, Convert.ToInt32(newViewState[2]));
                            int i = 0;
                            foreach (Control c in panelNameofParticipants.Controls)
                            {
                                if (c is Table)
                                {
                                    foreach (TableRow row in c.Controls)
                                    {
                                        foreach (TableCell cell in row.Controls)
                                        {
                                            if (cell.Controls[0] is TextBox && i < txtValues.Length)
                                            {
                                                ((TextBox)cell.Controls[0]).Text = txtValues[i++].ToString();
        
                                            }
                                        }
                                    }
                                }
                        }
                        }
                        //load the ViewState normally
                        base.LoadViewState(newViewState[1]);
                    }
                    else
                    {
                        base.LoadViewState(savedState);
                       
                    }
                }
    //Create Dynamic Control
    
    public void CreateDynamicTable(int rowcount, int columnCount)
            {
                Table tableparticipantName = new Table();
    
                 for (int i = 0; i < rowcount; i++)
                    {
                        TableRow row = new TableRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            TableCell cell = new TableCell();
                            
                            TextBox txtNameofParticipant = new TextBox();
                            txtNameofParticipant.ID = "txtNameofParticipant" + Convert.ToString(j);
                            cell.ID = "cell" + Convert.ToString(j);
                            cell.Controls.Add(txtNameofParticipant);
                            row.Cells.Add(cell);
                        }
                        tableparticipantName.Rows.Add(row);
                        tableparticipantName.EnableViewState = true;
                        ViewState["tableparticipantName"] = true;
            }
                 panelNameofParticipants.Controls.Add(tableparticipantName);
            }
