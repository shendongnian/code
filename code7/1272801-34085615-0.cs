    object  NumberUnitData = DataBinder.Eval(e.Row.DataItem, "Data");
                    if (NumberUnitData == null)
                    {
                        ddlNumberUnit.SelectedItem.Text = "";
                    }
                    else
                    {
                        ddlNumberUnit.SelectedItem.Text = NumberUnitData.ToString();
                    }
