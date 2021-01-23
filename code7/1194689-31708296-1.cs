    foreach ( string columnName in columns )
    {
         ColumnCollection.Add( new DataGridTextColumn()
		                       {
                       		       Header = columnName,
                   			       Binding = new Binding( String.Format( "[{0}]", columnName ) )
                               } );
    }
