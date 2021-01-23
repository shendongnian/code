		public void save ( object sender, EventArgs e )
		{
			DataRow row = (( DataTable ) Session[ "tab" ]).NewRow();
			for ( int i = 0; i < PlaceHolder1.Controls.Count; i++ )
			{
				string tbxid = string.Format( "TbxInput{0}", i );
				TextBox txt = ( TextBox ) PlaceHolder1.FindControl( tbxid );
				row[ i ] = txt.Text;
			}
			( ( DataTable ) Session[ "tab" ] ).Rows.Add( row );
			GridView1.DataBind();
		}
	
