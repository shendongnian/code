    protected void rgCallRecordings_FilterCheckListItemsRequested(object sender, GridFilterCheckListItemsRequestedEventArgs e)
        {
            // Get the list of calls stored in session
            var results = (IQueryable<DC_CR_RECORDING>)Session["CallRecordings"];
            var listResults = results.ToList();
            // Get the column name
            string dataField = (e.Column as IGridDataColumn).GetActiveDataField();
            // Get the filter expression of the grid to determine if there is
            string filterExpression = rgCallRecordings.MasterTableView.FilterExpression;
            // Initialise new list
            IEnumerable<DC_CR_RECORDING> DistinctList = new List<DC_CR_RECORDING>();
            
            // If there is a filter applied then enter the loop if there isn't then the filter expression will be empty 
            if (!String.IsNullOrEmpty(filterExpression))
            {                
                // Create a new list of strings to hold the sequence ids
                List<string> sequenceIds = new List<string>();
                // For each row in the radgrid...
                foreach (GridDataItem row in rgCallRecordings.Items) // loops through each rows in RadGrid
                {
                    // ...Add the sequence id to the list
                    sequenceIds.Add(row.GetDataKeyValue("SEQUENCE_ID").ToString());                    
                }
                // Only return results whose sequence ids are in the list
                results = results.Where(a => sequenceIds.Contains(a.SEQUENCE_ID));                
            }            
           
            // Depending on which column it is change the data output.
            switch (dataField)
            {
                case "SCRIPT_AGENT":
                    // Seperate the script agents from the call recordings
                    DistinctList = results.GroupBy(s => s.SCRIPT_AGENT).Select(group => group.First());                    
                    break;
                case "CLIENT_NAME":
                    // Seperate the Client name from the call recordings
                    DistinctList = results.GroupBy(s => s.CLIENT_NAME).Select(group => group.First());
                    break;
                case "CLIENT_REF_NUMBER":
                    // Seperate the Client name from the call recordings
                    DistinctList = results.GroupBy(s => s.CLIENT_REF_NUMBER).Select(group => group.First());
                    break;
                case "CLIENT_LINK_REF":
                    // Seperate the Client link reference from the call recordings
                    DistinctList = results.GroupBy(s => s.CLIENT_LINK_REF).Select(group => group.First());
                    break;
                case "SCRIPT_TYPE":
                    // Seperate the call direction from the call recordings
                    DistinctList = results.GroupBy(s => s.SCRIPT_TYPE).Select(group => group.First());
                    break;
                case "SCRIPT_RESULT":
                    // Seperate the call outcome from the call recordings
                    DistinctList = results.GroupBy(s => s.SCRIPT_RESULT).Select(group => group.First());
                    break;
            }
            RadListBoxItem rlbItem = new RadListBoxItem();
            // Bind the filter list box with the results corresponding to which column the user selected
            e.ListBox.DataSource = DistinctList;
            e.ListBox.DataKeyField = dataField;
            e.ListBox.DataTextField = dataField;
            e.ListBox.DataValueField = dataField;
            e.ListBox.DataBind();
            
        }
