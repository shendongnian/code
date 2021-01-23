        protected void Page_Load ( object sender, EventArgs e )
		{
			if ( !Page.IsPostBack )
			{
				Session[ "num" ] = 3;
				DataTable tab =   new DataTable();
				Session[ "tab" ] = tab;
				tab.Columns.Add( "Name" );
				tab.Columns.Add( "address" );
				tab.Columns.Add( "num" );
				Session[ "shown" ] = false;
			}
			GridView1.DataSource = ( DataTable ) Session[ "tab" ];
			CreateTbx();
		}
