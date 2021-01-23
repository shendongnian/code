    private void deleteButton_Click(object sender, EventArgs e)
    {
        gridView1.GetSelectedRows();
        GridView view = gridControl1.FocusedView as GridView;
        view.DeleteSelectedRows();
        //DB.SubmitChanges();
    }
