        protected void GridView1_RowDataBound( object sender, GridViewRowEventArgs e ) 
        {
		  if ( e.Row.RowType == DataControlRowType.DataRow ) 
          {
            // loop through cells and track span index (si)
			for ( int i = 0, si = 0; i < e.Row.Cells.Count; si = i) 
            {
              // compare adjacent cells for like data and hide as needed
			  while ( ++i < e.Row.Cells.Count && e.Row.Cells[ si ].Text == e.Row.Cells[ i ].Text )
				e.Row.Cells[ i ].Visible = false;
              // set span and, conditionally, special formatting
			  if ( ( e.Row.Cells[ si ].ColumnSpan = ( i - si ) ) > 1 ) 
              {
				e.Row.Cells[ si ].BackColor = Color.Beige;
				e.Row.Cells[ si ].HorizontalAlign = HorizontalAlign.Center;
			  }
			}
          }
		}
