      InsideDB = dr["Inside"].ToString();
                        if (InsideDB.ToString() != "")
                        {
                            Inside.SelectedValue = InsideDB.ToString();
                            Inside.Enabled = false;
                        }
                        else
                        {
                            Inside.Enabled = true;
                        }
