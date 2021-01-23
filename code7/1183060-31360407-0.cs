	/// <summary>
	/// Asynchronously read tables for this SqlLibAsync instance.
	/// </summary>
	public async Task ReadTables( ) {
		//this.DS = new DataSet( ); <-----This line of code has been moved...
		using ( MySqlConnection MSQCon = new MySqlConnection( this.ConnectionString ) ) {
			await MSQCon.OpenAsync( );
			try {
				this.DS = new DataSet( ); //<-----To here. Then, abra cadabra, my problem disappeared. What is this, I don't even...
				foreach ( MySqlDataAdapter Adapter in this.Adapters ) {
					Adapter.SelectCommand.Connection = MSQCon;
					await Adapter.FillAsync( this.DS, Adapter.TableMappings.Cast<DataTableMapping>( ).First( ).SourceTable );
				}
			} catch ( Exception ex ) {
				ex.Report( );
			}
			await MSQCon.CloseAsync( );
		}
		if ( this.DS.Tables.Count == 0 )
			await this.ReadTables( );
	}
