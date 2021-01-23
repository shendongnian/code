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
