    foreach (GridViewRow grv in customTableDataList.UniGrid.GridView.Rows){if (grv != null)
            {
                if (null != grv.FindControl(ItemCheckBoxID) && ((CheckBox)grv.FindControl(ItemCheckBoxID)).Checked)
                {
                     itemIds += customTableDataList.UniGrid.ActionsID.ToArray()[rowCounter] + ", ";  //At this line I am getting error.
                }
                rowCounter++;
            }
        }
