        protected void GridView1_RowDataBound( object sender, GridViewRowEventArgs e ) 
        {
		  if ( e.Row.RowType == DataControlRowType.DataRow ) 
			for ( int i = 0, si = 0; i < e.Row.Cells.Count; si = i) {
			  while ( ++i < e.Row.Cells.Count && e.Row.Cells[ si ].Text == e.Row.Cells[ i ].Text )
				e.Row.Cells[ i ].Visible = false;
			  e.Row.Cells[ si ].ColumnSpan = ( i - si );
			  if ( e.Row.Cells[ si ].ColumnSpan > 1 ) {
				e.Row.Cells[ si ].BackColor = Color.Beige;
				e.Row.Cells[ si ].HorizontalAlign = HorizontalAlign.Center;
			  }
			}
		}
