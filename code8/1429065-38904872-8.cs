    private void txtExpresion_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(System.String)))
        {
            string Item = (System.String)e.Data.GetData(typeof(System.String));
            string[] split = Item.Split(':');
            txtExpresion.SelectionLength = 0;
            txtExpresion.SelectedText = split[1];
        }
    }
    private void txtExpresion_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(typeof(string)))
        {
            e.Effect = DragDropEffects.Copy;
            txtExpresion.Focus();
        }
    }
    private void txtExpresion_DragOver(object sender, DragEventArgs e)
    {
        int cp = txtExpresion.GetCharIndexFromPosition(
                              txtExpresion.PointToClient(Control.MousePosition));
        txtExpresion.SelectionStart = cp;
        txtExpresion.Refresh();
    }
