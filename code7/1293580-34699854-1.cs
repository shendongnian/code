    private void common_dgv_DeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        e.Cancel = true;
        DataGridView dgv = sender as DataGridView;
        BindingSource bs = dgv.DataSource as BindingSource;
        bs.SuspendBinding();
        e.Row.Visible = false;
        bs.ResumeBinding();
        ((basex)e.Row.DataBoundItem).IsDeleted = true;
        SetFormMode(Globals.FormStatusMode.Save);
    }
