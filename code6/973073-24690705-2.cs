     private void tlAssemblies_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X -     dragSize.Width / 2,
                downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = viewProduct.GetDataRow(downHitInfo.RowHandle);
                    if(row != null)
                    tlAssemblies.DoDragDrop(row, DragDropEffects.Move); 
                    //viewProduct.GridControl.DoDragDrop(row, DragDropEffects.All); 
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }
