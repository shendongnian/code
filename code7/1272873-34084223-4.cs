    for (int j = 0; j < GrdRights.RowsInViewState.Count; j++)
    {
        bool str_checkadd = ((CheckBox)((GridDataControlFieldCell)GrdRights.RowsInViewState[j].Cells[4]).FindControl("ChkIDAdd")).Checked;
        bool str_checkEdit = ((CheckBox)((GridDataControlFieldCell)GrdRights.RowsInViewState[j].Cells[5]).FindControl("ChkIDEdit")).Checked;
        bool str_checkView = ((CheckBox)((GridDataControlFieldCell)GrdRights.RowsInViewState[j].Cells[6]).FindControl("ChkIDView")).Checked;
        bool str_checkdel = ((CheckBox)((GridDataControlFieldCell)GrdRights.RowsInViewState[j].Cells[7]).FindControl("ChkIDDelete")).Checked;
        // ....
    }
