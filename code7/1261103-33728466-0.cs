                            CheckBoxList CheckBoxList1 = (CheckBoxList)aItem.FindControl("CheckBoxList1");
                            foreach (ListItem listItem in CheckBoxList1.Items)
                            {
                                if (listItem.Selected)
                                {
                                    sqlCmd2.CommandText = string.Format("UPDATE FormField SET Visible = 0 WHERE MyField = '{0}';", listItem.Value);
                                    sqlCmd2.ExecuteNonQuery();
                                }
                                else
                                {
                                    //do something else
                                }
                            }
