    private void grd_Paint ( object sender, PaintEventArgs e)
    {
        DataGridView sender= ( DataGridView )sender;
    
        if ( sender.Rows.Count == 0 ) 
        {
            using ( Graphics g= e.Graphics )
            {
                g.FillRectangle ( Brushes.White, new Rectangle ( new Point (), new Size ( sender.Width, 25 ) ) );
                g.DrawString ( "No data to display", new Font ( "Arial", 12 ), Brushes.Red, new PointF ( 3, 3 ) );
            }
        }
    }
      
