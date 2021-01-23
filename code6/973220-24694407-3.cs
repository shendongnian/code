    protected void repRequests_ItemDataBound(object sender, RepeaterItemEventArgs e)
        		{
        			if (e.Item.ItemType == ListItemType.Item ||
        				e.Item.ItemType == ListItemType.AlternatingItem)
        			{
        				System.Data.Common.DbDataRecord dataRow = e.Item.DataItem as System.Data.Common.DbDataRecord;
        
        				if (dataRow["accepted_id"] == DBNull.Value || dataRow["accepted_id"] == null) // a column from the db table
        				{
                            Panel panelRow = e.Item.FindControl("panelRow") as Panel;
                            panelRow.CssClass = "yourcssclass";
        			
        				}
        			}
        		}
