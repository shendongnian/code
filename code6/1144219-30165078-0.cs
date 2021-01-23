     protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
     {
        if (keyData == Keys.Tab && dgCoreRoutes.CurrentCell.RowIndex == dgCoreRoutes.Rows.Count-1)
        {
           dgCoreRoutes.TabStop = true;
           //return true;
           //Use standardTab = true; if you want to tab only standard columns and not cells.
        }
 
    else if (keyData == Keys.Tab && dgCoreRoutes.CurrentCell.ReadOnly)
    {
           dgCoreRoutes.CurrentCell = GetCoreRoutesGridNextCell(dgCoreRoutes.CurrentCell);
           e.Handled = true;
           return true;
    }
         else
               return base.ProcessCmdKey(ref msg, keyData);
        }
