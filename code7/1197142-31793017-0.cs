    private void treeListView_ItemActivate(object sender, EventArgs e)
    {
        try
        {
            var se = (StructureElement)treeListView.GetItem(treeListView.SelectedIndex).RowObject;
            MessageBox.Show(se.id.ToString());
        }
        catch (Exception e3)
        {
            globals.logfile.error(e3.ToString());
            globals.logfile.flush();
        }
        finally
        {
        }
    }
