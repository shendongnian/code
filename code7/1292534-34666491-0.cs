    private void AddButton_Click(object sender, EventArgs e)
    {
        ((DataRowView)allUrlsDGV.CurrentRow.DataBoundItem)["Favorite"] = true;
        ((DataRowView)allUrlsDGV.CurrentRow.DataBoundItem).EndEdit();
    }
    private void RemoveButton_Click(object sender, EventArgs e)
    {
        ((DataRowView)favoriteUrlsDGV.CurrentRow.DataBoundItem)["Favorite"] = false;
        ((DataRowView)favoriteUrlsDGV.CurrentRow.DataBoundItem).EndEdit();
    }
    private void allUrlsDGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        var f = e.InheritedRowStyle.Font;
        var dataRowView = allUrlsDGV.Rows[e.RowIndex].DataBoundItem as DataRowView;
        if (dataRowView != null && dataRowView.Row.Field<bool>("Favorite") == true)
            allUrlsDGV.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(f, FontStyle.Bold);
        else
            allUrlsDGV.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(f, FontStyle.Regular);
    }
