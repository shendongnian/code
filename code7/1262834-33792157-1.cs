    private void checklist_dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
    	if (e.RowIndex > -1 )
    	{
    		e.Handled = true;
    		e.Graphics.FillRectangle(System.Drawing.Brushes.Black, e.CellBounds);                
    
    		using (Pen p = new Pen(Brushes.LightGreen))
    		{
    			p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
    			e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom - 1), new Point(e.CellBounds.Right, e.CellBounds.Bottom - 1));
    		}
    
    		e.PaintContent(e.ClipBounds);
    	}
    }
