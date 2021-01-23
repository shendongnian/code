    private void GvOnRowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    for (int i = 0; i < e.Row.Cells.Count;i++)
                    {
                        var customAttributes =
                            typeof (YourClass).GetProperty(e.Row.Cells[i].Text).CustomAttributes.ToList();
                        var displayNameAttribute =
                            customAttributes.FirstOrDefault(
                                aa => aa.AttributeType.FullName.Equals("System.ComponentModel.DisplayNameAttribute"));
                        if (displayNameAttribute != null)
                            e.Row.Cells[i].Text = displayNameAttribute.ConstructorArguments[0].ToString();
                    }
                }
            }
