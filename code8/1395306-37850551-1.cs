    foreach (GridViewRow gvrow in testResultsGridView.Rows)
    {
       if(gvrow.RowType == DataControlRowType.DataRow)
       {
            CheckBox chk = (CheckBox)gvrow.FindControl("cbSelect");
            if (chk != null && chk.Checked)
            {
                 id = Int32.Parse(((Label)gvrow.FindControl("rowId")).Text); ;
                UpdateTestCase(id, rootCause, subCategory, comment, RTC, reRunStatus);
            }
        }
    }
