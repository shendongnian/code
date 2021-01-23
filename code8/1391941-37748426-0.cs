    string FirstTableSelectedColumns = "";
                    for (int i = 0; i < chkTblListDb001.Items.Count; i++)
                    {
                        if (chkTblListDb001.GetItemChecked(i))
                        {
                            //FirstTableSelectedColumns += chkTblListDb001.Items[i].ToString() + ",";
                            FirstTableSelectedColumns += ((DataRowView)chkTblListDb001.Items[i])[0].ToString() + ",";
                            MessageBox.Show(FirstTableSelectedColumns);
                        }
                    }
