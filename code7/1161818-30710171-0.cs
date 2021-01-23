    static bool IsAnyCellEmpty(DataGridView gridView, params int[] columnIndexes)
    		{
    			bool result = false;
    			foreach (DataGridViewRow row in gridView.Rows)
    			{
    				foreach (var index in columnIndexes)
    				{
    					if (row.Cells[index].Value.ToString().Trim().Length == 0)
    					{
    						result = true;
    						break;
    					}
    				}
    			}
    			return result;
    		}
