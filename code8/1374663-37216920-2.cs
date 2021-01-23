			GridViewRow row = new GridViewRow( 0, -1, DataControlRowType.Header, DataControlRowState.Normal );
			TableCell th = new TableHeaderCell();
			th.HorizontalAlign = HorizontalAlign.Center;
			th.ColumnSpan = gv.Columns.Count;
			th.Font.Bold = true;
			th.Text = HeaderText;
			row.Cells.Add( th );
			InnerTable.Rows.AddAt( 0, row );
		}
