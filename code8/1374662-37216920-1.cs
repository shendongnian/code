		Table InnerTable = ( Table ) GridView1.Controls[ 0 ];
		foreach ( GridViewRow r in InnerTable.Rows ) {
			if (r.RowType == DataControlRowType.Header){
				CheckBox chk = (CheckBox) r.FindControl( "chk" );
			}
		}
