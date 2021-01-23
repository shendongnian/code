        int HeaderRowCount = -5;  // initialized to a wrong starting point
		protected void GridView1_DataBinding( object sender, EventArgs e ) {
			HeaderRowCount = 0;  // this event starts the binding and row creation process
		}
        // Each row is created and Bound in the order of the dataset.
		protected void GridView1_RowCreated( object sender, GridViewRowEventArgs e ) {
            // Are we creating the Header Row?
			if ( e.Row.RowType == DataControlRowType.Header ) {
                // Create your additional Headers here:  AddHeaderRow() is defined below
				AddHeaderRow( ( GridView ) sender, "Hi I'm a header" );
			}
		}
		protected void GridView1_RowDataBound( object sender, GridViewRowEventArgs e ) {
			if ( e.Row.RowType == DataControlRowType.Header ) {
				HeaderRowCount++;
			}
		}
		protected void GridView1_DataBound( object sender, EventArgs e ) {
			GridView1.Caption = string.Format( "HeaderRowCount: {0}", HeaderRowCount);
		}
