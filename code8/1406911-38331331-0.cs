                    ArrayList selected = new ArrayList();
                    for (int i = 0; i < chkRoles.Items.Count; i++) //chkRoles being the CheckBoxList
                    {
                        if (chkRoles.GetItemChecked(i))
                            selected.Add(chkRoles.Items[i].ToString()); //And I just added what was checked to the Arraylist. String values
                    }
