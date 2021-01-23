    private void lst_Install_Item_Main_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                try
                {
                    //Get Column which clicked
                    DataGridViewColumn newColumn = lst_Install_Item_Main.Columns[e.ColumnIndex];
                    //Get Values from DataGrid
                    List<test> temp = (List<test>)lst_Install_Item_Main.DataSource;
                    
                    //Get the sorting order for that column
                    string orderby = GetOrder(newColumn.DataPropertyName);
    
                    if (orderby == ListSortDirection.Ascending.ToString()) //Ascending
                    {
                        if (newColumn.DataPropertyName == "feet") //Feet column sort with double value and required trim
                        {
                            temp = temp.OrderBy(x => Convert.ToDouble(x.feet.Trim('\''))).ToList();
                        }
                        else if (newColumn.DataPropertyName == "shapelen") //Shapelen column sort with double value and required trim
                        {
                            temp = temp.OrderBy(x => Convert.ToDouble(x.shapelen.Trim('\''))).ToList();
                        }
                        else ///other columns having string value only.
                        {
                            temp = temp.OrderBy(x => x.GetType().GetProperty(newColumn.DataPropertyName).GetValue(x, null)).ToList();
                        }
                    }
                    else // Descending 
                    {
                        if (newColumn.DataPropertyName == "feet") //Feet column sort with double value and required trim
                        {
                            temp = temp.OrderByDescending(x => Convert.ToDouble(x.feet.Trim('\''))).ToList();
                        }
                        else if (newColumn.DataPropertyName == "shapelen")  //Shapelen column sort with double value and required trim
                        {
                            temp = temp.OrderByDescending(x => Convert.ToDouble(x.shapelen.Trim('\''))).ToList();
                        }
                        else //other columns having string value only.
                        {
                            temp = temp.OrderByDescending(y => y.GetType().GetProperty(newColumn.DataPropertyName).GetValue(y, null)).ToList();
                        }
                    }
                    lst_Install_Item_Main.DataSource = temp;
                    lst_Install_Item_Main.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while sorting \n" + ex.Message, "Closeout Calculator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
    
            private string GetOrder(string columnName)
            {
                //Store the each coulmn(Ascending/Descending) values to make it dynamic 
                string ord = sortOrder[0].GetType().GetProperty(columnName).GetValue(sortOrder[0], null).ToString();
                if (ord == ListSortDirection.Ascending.ToString())
                {
                    sortOrder[0].GetType().GetProperty(columnName).SetValue(sortOrder[0], ListSortDirection.Descending.ToString(), null);
                }
                else
                { sortOrder[0].GetType().GetProperty(columnName).SetValue(sortOrder[0], ListSortDirection.Ascending.ToString(), null); }
                return ord;
            }
