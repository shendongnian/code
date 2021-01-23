        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "id"));
            
            int i, j;
            for (i = 1; i <= 65; i++)
            {
               
                j = i + 100;
              string k = i.ToString();
                string l = j.ToString();
                
                if (ViewState[l] != null)
                {
                    if (id == k)
                    {
                       
                        if (ViewState[l].ToString() == "A")
                        {
                            
                            (e.Row.Cells[0].FindControl("RadioButton1") as RadioButton).Checked = true;
                        }
                        if (ViewState[l].ToString() == "B")
                        {
                            (e.Row.Cells[0].FindControl("RadioButton2") as RadioButton).Checked = true;
                        }
                        if (ViewState[l].ToString() == "C")
                        {
                            (e.Row.Cells[0].FindControl("RadioButton3") as RadioButton).Checked = true;
                        }
                        if (ViewState[l].ToString() == "D")
                        {
                            (e.Row.Cells[0].FindControl("RadioButton4") as RadioButton).Checked = true;
                        }
                    }
                }
            }
        }
    }
