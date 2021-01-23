    void EditSearchField_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Apps)
      {
        if (dgvClients.SelectedRows.Count > 0)
        {
          // force the selected row to be visible, or else we could get a .NET debugger
          dgvClients.CurrentCell = dgvClients.SelectedRows[0].Cells[0];
          
          // prepare context menu (disable inaccessible entries)
          Point ptMouse = dgvClients.GetCellDisplayRectangle(0, dgvClients.SelectedRows[0].Index, false).Location;
          var mouseEvtArgs = new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0);
          var mouseDgvArgs = new DataGridViewCellMouseEventArgs(0, dgvClients.SelectedRows[0].Index, ptMouse.X, ptMouse.Y, mouseEvtArgs);
          DgvClientsMouseDown(dgvClients, mouseDgvArgs);
          
          // calculate location for the context menu and finally show it
          Point ptContextMenuPos = dgvClients.PointToScreen(ptMouse);
          ptContextMenuPos.X += dgvClients.Width / 2;
          ptContextMenuPos.Y += dgvClients.RowTemplate.Height / 2;
          dgvClients.ContextMenuStrip.Show(ptContextMenuPos);
        }
        e.Handled = true;
        e.SuppressKeyPress = true;
      }
    }
