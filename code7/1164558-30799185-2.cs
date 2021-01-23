            private void btnGroup_Click(object sender, EventArgs e)
            {
                //See: https://stackoverflow.com/questions/30785736/editing-datagridview-data-changes-row-orders
    
                List<int> groupNumbersAll = new List<int>();
                List<int> groupNumbersNotSelected = new List<int>();
                List<int> groupNumbersSelected = new List<int>();
                List<int> rowNumbersSelected = new List<int>();
                List<int> groupNumbersOfEntirelySelectedGroups = new List<int>();
    
                DataTable dt = (DataTable)dgvVolReport.DataSource;
    
                // Populate groups (All, Selected and NotSelected)
                for (int r = 0; r < dt.Rows.Count; r++)
                {
                    int group = Convert.ToInt16(dt.Rows[r]["Group"]);
                    groupNumbersAll.Add(group);
    
                    bool selected = false;
                    foreach (DataGridViewRow gridrow in dgvVolReport.SelectedRows)
                    {
                        DataRowView dr = (DataRowView)gridrow.DataBoundItem;
                        selected |= dr.DataView.Table.Rows.IndexOf(dr.Row) == r;
                    }
    
                    if (selected)
                    {
                        groupNumbersSelected.Add(group);
                        rowNumbersSelected.Add(r);
                    }
                    else
                    {
                        groupNumbersNotSelected.Add(group);
                    }
                }
    
                int smallestSelectedGroupNumber = groupNumbersSelected.Min();
                int newGroupNumber = smallestSelectedGroupNumber;
                bool newGroupFlag = false;
                // If the selected rows do not contain all rows with group number equal to the smallest selected group number,
                // then we need to create a new group whose group number is the smallest selected group number plus 1.
                // This then implies that we need to add 1 to the group number of every row with a group number larger than the
                // lowest selected group number (that is the original lowest selected number before we added 1).
                if (groupNumbersNotSelected.Contains(smallestSelectedGroupNumber))
                {
                    newGroupNumber++;
                    newGroupFlag = true;
                }
    
                // Find which groups have been selected entirely, but ignore the smallest number. 
                // If a group has been entirely selected it means that that group number will no longer exist. Thus we will have to 
                // subtract 1 from each group number that is larger than a group that has been entirely selected. This process is 
                // cumulative, so if a number is higher than 2 entirely selected groups (excluding the smallest selected group) then
                // we need to subtract 2 from the group number.
                foreach (int group in groupNumbersSelected.Distinct())
                {
                    if (!groupNumbersNotSelected.Contains(group) && !(group == smallestSelectedGroupNumber))
                    {
                        groupNumbersOfEntirelySelectedGroups.Add(group);
                    }
                }
    
                // Find the new group numbers
                for (int r = 0; r < groupNumbersAll.Count; r++)
                {
                    int groupNum = groupNumbersAll[r];
    
                    if (rowNumbersSelected.Contains(r))
                    {
                        groupNumbersAll[r] = newGroupNumber;
                    }
                    else
                    {
                        int subtract = groupNumbersOfEntirelySelectedGroups.Where(num => num < groupNum).Count();
    
                        if (newGroupFlag && groupNum >= newGroupNumber)
                        {
                            groupNum++;
                        }
    
                        groupNumbersAll[r] = groupNum - subtract;
                    }
                }
    
                for (int n = 0; n < dt.Rows.Count; n++)
                {
                    dt.Rows[n]["Group"] = groupNumbersAll[n];
                }   
    
                dgvVolReport.Sort(colGroup, ListSortDirection.Ascending);
            }
