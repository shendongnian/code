    //NOTE: Rows[i] this i is from the loop (int i = 0; i < GridView1.Rows.Count; i++)
    int justtocheck = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
    SPListItem newStat = list.Items.GetItemById(justtocheck);
                        {
                            web.AllowUnsafeUpdates = true;
                            newStat["Status"] = drpDwnStat.SelectedItem.Text;
                            newStat.Update();
                            web.AllowUnsafeUpdates = false;
                        }
