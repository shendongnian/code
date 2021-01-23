                        while (sdr.Read())
                    {
                        ListItem currentCheckBox = cbAvailableEntities.Items.FindByValue(sdr["CorpID"].ToString());
                        if(currentCheckBox != null)
                        {
                            currentCheckBox.Selected = true;
                        }
                    }
